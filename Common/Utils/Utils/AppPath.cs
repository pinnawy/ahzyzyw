using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElpMaster.Common.Utils
{
    public class AppPath
    {
        public static string GetAppRootPath()
        {
            string appDir = string.Empty;
            if (System.Web.HttpContext.Current == null)
                appDir = AppDomain.CurrentDomain.BaseDirectory;
            else
                appDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!appDir.EndsWith("\\")) appDir += "\\";
            return appDir;
        }
    }
}
