using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using ElpSimWan.Json;
using ElpSimWan.Utils;

namespace Library
{
    /// <summary>
    /// This class is used to process the HTTP request command from javascript
    /// or web page, it accept action and parameters from client and follow to business logic tie.
    /// </summary>
    public class HttpProcessor
    {
        public const string HTTP_ACTION_COMMAND = "action";

        private static HttpProcessor _this;
        public static object Process(object instance, HttpContext context)
        {
            if (_this == null)
            {
                Init();
            }

            //查找对应的接口
            string action = context.Request[HTTP_ACTION_COMMAND];
            MethodInfo methodToInvoke = FindMethods(instance.GetType(), action);
            if (methodToInvoke == null)
            {
                LogUtil.Log.Warn("HttpProcessor::Process, invalid request command: " + action);
                throw new InvalidOperationException(action);
            }

            //获取参数
            IDictionary<string, string> parameters = GetPostParameters(context);

            //调用
            return InvokeMethod(instance, methodToInvoke, parameters);
        }

        #region private functions

        private static void Init()
        {
            _this = new HttpProcessor();
        }

        private static IDictionary<string, string> GetPostParameters(HttpContext context)
        {
            Dictionary<string, string> parameterDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string[] keys = { };
            if (context.Request.Form.AllKeys.Length < 1)
                keys = context.Request.QueryString.AllKeys;
            else if (context.Request.Form.AllKeys.Length > 0)
                keys = context.Request.Form.AllKeys;

            foreach (string requestParam in keys)
            {
                if (requestParam == HTTP_ACTION_COMMAND)
                    continue;

                var value = context.Request.QueryString[requestParam] ?? context.Request.Params[requestParam];
                parameterDict.Add(requestParam, context.Server.UrlDecode(value));
            }

            parameterDict.Remove("timestamp"); //去除时间戳 add by yuwang 2010-12-24
            return parameterDict;
        }

        private static MethodInfo FindMethods(Type type, string methodName)
        {
            MethodInfo foundMatch = null;

            MemberInfo[] memberInfos = type.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public);
            foreach (MemberInfo memberInfo in memberInfos)
            {
                if (memberInfo.MemberType == MemberTypes.Method)
                {
                    MethodInfo methodInfo = (MethodInfo)memberInfo;
                    string compMethodName = char.ToLower(methodInfo.Name[0]) + methodInfo.Name.Substring(1);
                    if ((!methodInfo.IsSpecialName) && compMethodName.ToLower() == methodName.ToLower())
                    {
                        foundMatch = methodInfo;
                        break;
                    }
                }
            }

            return foundMatch;
        }

        private static object InvokeMethod(object instance, MethodInfo methodInfo, IDictionary<string, string> parameters)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            ParameterInfo[] parameterInfos = methodInfo.GetParameters();
            if (parameterInfos.Length != parameters.Count)
            {
                throw new InvalidOperationException("Wrong parameters count: " + methodInfo.Name);
            }

            object[] parametersArray = (from parameterInfo
                                        in parameterInfos
                                        select ExtractParameterFromDictionary(parameterInfo, parameters)).ToArray();
            object returnValue = methodInfo.Invoke(instance, parametersArray);

            //recordCount ??
            string recordCount = "";
            parameters.TryGetValue("recordCount", out recordCount);
            if (!String.IsNullOrEmpty(recordCount))
            {
                returnValue = "{" + String.Format("total:{0},rows:{1}", parametersArray[parametersArray.Length - 1], returnValue.ToJSON()) + "}";
            }
            if (returnValue == null)
            {
                returnValue = "null";
            }
            return returnValue;
        }

        private static object ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary<string, string> parameters)
        {
            string value;
            bool wasFound = parameters.TryGetValue(parameterInfo.Name, out value);

            if (wasFound)
            {
                if (value == null)
                {
                    value = "null";
                }

                Type pramType = parameterInfo.ParameterType;

                try
                {
                    if (pramType.FullName == "System.Int32&")
                    {
                        return 0;
                    }

                    if (pramType.Equals(typeof(Guid)))
                    {

                        return new Guid(value);
                    }

                    if ((pramType.IsByRef || pramType.IsEnum || pramType.IsClass) && pramType.FullName != "System.String")
                    {
                        return value.DeserializeObject(pramType);
                    }

                    return Convert.ChangeType(value, pramType);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return value;
        }

        #endregion
    }
}
