using System;
using System.Web;
using Ahzyzyw.BLL.Interface;
using ElpSimWan.Json;
using ElpSimWan.Utils;
using Library;

namespace Ahzyzyw.Web.Services
{
    /// <summary>
    /// Summary description for Resource
    /// </summary>
    public class News : IHttpHandler
    {
        private readonly INewsBLL _newsBLL = UnityContext.LoadBllModel<INewsBLL>();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                var result = HttpProcessor.Process(_newsBLL, context);
                if (result is string)
                {
                    context.Response.Write(result.ToString());
                }
                else
                {
                    context.Response.Write(result.ToJSON());
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("Resource Handler Exception:", ex);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}