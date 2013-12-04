using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualBasic.Logging;
using log4net;

namespace ElpSimWan.Utils
{
    /// <summary>
    /// 日志类.在使用前需要调用Init 初始化
    /// </summary>
    public class LogUtil
    {
        private static ILog log;

        static LogUtil()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 根据主程序的assembly name 初始化日志
        /// </summary>
        /// <param name="assemblyType">主程序类别</param>
        public static void Init(Type assemblyType)
        {
            string logName = assemblyType.Assembly.GetName().Name;
            Init(logName);
        }

        /// <summary>
        /// 根据配置的日志名初始化日志
        /// </summary>
        /// <param name="logName">配置的日志名称</param>
        public static void Init(string logName)
        {
            log = LogManager.GetLogger(logName);
            WriteHead();
        }

        /// <summary>
        /// 写文件头部
        /// </summary>
        private static void WriteHead()
        {
            StringBuilder sb = new StringBuilder();

            Process curProcess = Process.GetCurrentProcess();
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.AppendLine("*============================================================");
            sb.AppendLine("Subject:   Ahzyzyw Log File");
            sb.AppendLine("BeginTime: " + DateTime.Now.ToString("yyyy/MM/dd,HH:mm:ss,fff"));
            sb.AppendLine("MainApp:   " + curProcess.MainModule.FileName);
            sb.AppendLine("Version:   " + curProcess.MainModule.FileVersionInfo.FileVersion);
            sb.AppendLine(string.Format("ProcessID: {0:D}(0x{0:X4})", curProcess.Id));
            sb.AppendLine("=============================================================");
            Log.Info(sb.ToString());
        }

        public static ILog Log
        {
            get
            {
                //如果没有调Init方法,为不使程序崩溃.配置一个日志
                return log ?? LogManager.GetLogger("default");
            }
        }
    }
}
