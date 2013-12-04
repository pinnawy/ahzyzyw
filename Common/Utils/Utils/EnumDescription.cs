using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace ecl.Common.Comm
{
    public class EnumDescription
    {
        /// <summary>
        /// 获取枚举类子项描述信息
        /// <remarks>由于系统中使用了中文的角色信息，枚举类型不支持STRING，所以添加此类，以获取枚举类子项的描述信息</remarks>
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>        
        public static string GetEnumDescription(Enum enumSubitem)
        {
            Object obj = GetAttributeClass(enumSubitem, typeof(DescriptionAttribute));
            if (obj == null)
            {
                return enumSubitem.ToString();
            }
            else
            {
                DescriptionAttribute da = (DescriptionAttribute)obj;
                return da.Description;
            }
        }

        /// <summary>
        /// 获取自定义属性的描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>
        /// <param name="text"></param>
        /// <param name="test"></param>
        public static void GetEnumAttributeInfo(Enum enumSubitem, out string text, out string test)
        {
            Object obj = GetAttributeClass(enumSubitem, typeof(EnumAttribute));
            if (obj == null)
            {
                text = test = enumSubitem.ToString();
            }
            else
            {
                EnumAttribute da = (EnumAttribute)obj;
                text = da.DisplayText;
                test = da.DisplayTest;
            }
        }

        /// <summary>
        /// 获取指定属性类的实例
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>
        /// <param name="attributeType">DescriptionAttribute属性类或其自定义属性类 类型，例如：typeof(DescriptionAttribute)</param>
        private static Object GetAttributeClass(Enum enumSubitem, Type attributeType)
        {
            FieldInfo fieldinfo = enumSubitem.GetType().GetField(enumSubitem.ToString());
            Object[] objs = fieldinfo.GetCustomAttributes(attributeType, false);
            if (objs == null || objs.Length == 0)
            {
                return null;
            }
            return objs[0];
        }

        /// <summary>
        /// 自定义的一个属性类
        /// </summary>
        public class EnumAttribute : Attribute
        {
            public EnumAttribute(string displayText, string displayTest)
            {
                m_DisplayText = displayText;
                m_DisplayTest = displayTest;
            }            
            
            private string m_DisplayText = string.Empty;
            public string DisplayText
            {
                get { return m_DisplayText; }
            }

            private string m_DisplayTest = string.Empty;
            public string DisplayTest
            {
                get { return m_DisplayTest; }
            }
        }

        public static char[] GetEnumDescription()
        {
            throw new NotImplementedException();
        }
    }
}
