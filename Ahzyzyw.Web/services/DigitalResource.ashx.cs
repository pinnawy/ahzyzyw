using System;
using System.Web;
using Ahzyzyw.BLL.Interface;
using ElpSimWan.Json;
using ElpSimWan.Utils;
using Library;
using System.IO;
using System.Drawing;
using Utils;

namespace Ahzyzyw.Web.Services
{
    /// <summary>
    /// Summary description for Resource
    /// </summary>
    public class DigitalResource : IHttpHandler
    {
        private readonly IDigitalResourceBLL _digitalResBLL = UnityContext.LoadBllModel<IDigitalResourceBLL>();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                var result = HttpProcessor.Process(_digitalResBLL, context);
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
                LogUtil.Log.Error("DigitalResource Handler Exception:", ex);
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