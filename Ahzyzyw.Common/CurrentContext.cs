using System;
using System.Configuration;
using System.Web;

namespace Ahzyzyw.Common
{
    public sealed class CurrentContext
    {
        private CurrentContext()
        {

        }

        static CurrentContext()
        {
            _appRoot = AppDomain.CurrentDomain.BaseDirectory;
        }

        private static volatile CurrentContext _instance = new CurrentContext();
        public static CurrentContext Instance
        {
            get { return _instance; }
        }

        private static string _appRoot;
        /// <summary>
        /// 网站应用程序根路径
        /// </summary>
        public string AppRoot
        {
            get { return _appRoot; }
        }

        /// <summary>
        /// 网站Url根路径
        /// </summary>
        public string WebUrlRoot
        {
            get
            {
                return HttpContext.Current == null ? string.Empty : HttpContext.Current.Server.MapPath("~");
            }
        }

        private readonly string _resourceDir = HttpContext.Current.Server.MapPath("~/" + ConfigurationManager.AppSettings["ResourceDir"]);
        /// <summary>
        /// 资源物理目录
        /// </summary>
        public string ResourceDir
        {
            get { return _resourceDir; }
        }

        private readonly string _tempDir = HttpContext.Current.Server.MapPath("~/" + ConfigurationManager.AppSettings["TempDir"]);
        /// <summary>
        /// 临时文件夹名称
        /// </summary>
        public string TempDir
        {
            get { return _tempDir; }
        }

        /// <summary>
        /// 默认资源名称
        /// </summary>
        public string DefaultResImageName
        {
            get { return "resDefaultImage.jpg"; }
        }
    }
}
