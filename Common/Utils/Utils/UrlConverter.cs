using System;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace Utils
{
    public class UrlConverter
    {
        /// <summary>
        /// ��������·��,�Ӹ�(~)��ʼ
        /// </summary>
        /// <param name="physicalPath">����·��</param>
        /// <returns>����·��</returns>
        public static string GetRowUrlFromPhysicalPath(string physicalPath)
        {
            if (string.IsNullOrEmpty(physicalPath))
                return "";

            if (HttpContext.Current == null)
                return "";

            string curPhysicalPath = HttpContext.Current.Server.MapPath("~");
            int pos = physicalPath.IndexOf(curPhysicalPath);
            if (pos >= 0)
                return "~/" + physicalPath.Substring(pos + curPhysicalPath.Length).Replace(Path.DirectorySeparatorChar, '/');
            
            return string.Empty;
        }
        /// <summary>
        /// ��·��ת��Ϊhttp·��
        /// </summary>
        /// <param name="path">����·��������·��</param>
        /// <returns></returns>
        public static string GetHttpUrl(string path)
        {
            if (HttpContext.Current == null)
                return string.Empty;

            // Http Urlֱ�ӷ���
            if (path.IndexOf("http://", StringComparison.OrdinalIgnoreCase) == 0)
                return path;

            // ����·��
            if (!(path.Length >= 2 && path[1] == Path.VolumeSeparatorChar))
                path = HttpContext.Current.Server.MapPath(path);

            string currPhysicalPath = HttpContext.Current.Server.MapPath("~");      // ��ǰ��վ���ڴ���·��
            int pos = path.IndexOf(currPhysicalPath);
            if (pos >= 0)
            {
                string url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                if (HttpContext.Current.Request.Url.Port != 80)
                    url += ":" + HttpContext.Current.Request.Url.Port.ToString();

                url += HttpContext.Current.Request.ApplicationPath + path.Substring(pos + currPhysicalPath.Length);
                url = url.Replace(Path.DirectorySeparatorChar, '/');
                return url;
            }

            return path;
        }

        /// <summary>
        /// ��������·��,�Ӹ�(~)��ʼ
        /// </summary>
        /// <param name="physicalPath">����·��</param>
        /// <returns>����·��</returns>
        public static string GetVirtualPath(string physicalPath)
        {
            if (HttpContext.Current == null)
                return "";

            string curPhysicalPath = HttpContext.Current.Server.MapPath("~");
            int pos = physicalPath.IndexOf(curPhysicalPath);
            if (pos >= 0)
                return "~/" + physicalPath.Substring(pos + curPhysicalPath.Length).Replace(Path.DirectorySeparatorChar, '/');
            
            return "~";
        }

        public static string GetRowUrlFromVirtualUrl(string fullUrl)
        {
            try
            {
                string physicalPath = GetPhysicalPathFromVirtualUrl(fullUrl);
                string virtualPath = GetRowUrlFromPhysicalPath(physicalPath);

                return virtualPath;
            }
            catch (Exception)
            {
                return (new Uri(fullUrl).AbsolutePath);
            }
        }

        public static string GetPhysicalPathFromVirtualUrl(string fullUrl)
        {
            if (HttpContext.Current == null)
                return string.Empty;

            try
            {
                Uri u = new Uri(fullUrl);
                string absPath = u.AbsolutePath;
                absPath = HttpContext.Current.Server.UrlDecode(absPath);
                return HttpContext.Current.Server.MapPath(absPath);
            }
            catch (Exception)
            {
                return HttpContext.Current.Server.MapPath(fullUrl);
            }
        }
    }
}
