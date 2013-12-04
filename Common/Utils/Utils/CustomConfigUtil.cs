/*
Custom configuration support
 * jhzhang 2010/11/9
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using StaticDust.Configuration;
using System.Configuration;
using System.Web;

namespace ecl.Common.Comm
{
    public class CustomConfigUtil
    {
        #region ConfigFile - 配置文件位置;
        private static string m_ConfigFile = "";

		/// <summary>
		/// 可在 Web.config appSettings 中配置 ConfigFile的位置和名称，
		/// 如果没有配置默认使用应用程序的名称作为配置文件的名称，
		/// 如果没有配置默认使用位置
		/// </summary>
        public static string ConfigFile
        {
            get
            {
                if (m_ConfigFile == "")
                {
                    string appDir = string.Empty;
                    if (System.Web.HttpContext.Current == null)
                        appDir = AppDomain.CurrentDomain.BaseDirectory;
                    else
                        appDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    if (!appDir.EndsWith("\\")) appDir += "\\";
					//检查是否在 config 文件中设置了 ConfigFile
					string configFile = ConfigurationManager.AppSettings["ConfigFile"];

					//如果没有设置，自动使用应用程序名称
					if (string.IsNullOrEmpty(configFile))
					{
						DirectoryInfo di = new DirectoryInfo(appDir);
						configFile = di.Name + ".config";
					}

					if (File.Exists(configFile))
					{
						m_ConfigFile = configFile;
					}
					else if (File.Exists(appDir + "@config\\" + configFile))
					{
						m_ConfigFile = appDir + "@config\\" + configFile;
					}
					else
					{
						//从 Utils.dll开始逐层目录查找 ConfigFilesPath.config，找到其中的配置文件位置
						Assembly myAssembly = Assembly.GetExecutingAssembly();
						string configFilePath = myAssembly.CodeBase;
						//LogUtil.Log.Info("CustomConfigUtil:ConfigFile, dll path is: " + configFilePath);
						if (configFilePath.IndexOf("file:///") > -1)
							configFilePath = configFilePath.Substring("file:///".Length);
						DirectoryInfo dr = new DirectoryInfo(Path.GetDirectoryName(configFilePath));

						bool bFind = false;
						while(true)
						{
							string searchPath = Path.Combine(dr.FullName, "ConfigFilesPath.config");
							//LogUtil.Log.Info("CustomConfigUtil:ConfigFile, Search path: " + searchPath);
							if (File.Exists(searchPath))
							{
								StaticDust.Configuration.AppSettingsReader configReader = CustomConfigurationSettings.AppSettings(searchPath);
								if(configReader.Contains("ConfigFilesPath"))
								{
									m_ConfigFile = Path.Combine(configReader["ConfigFilesPath"].ToString(), configFile);
									//LogUtil.Log.Info("CustomConfigUtil:ConfigFile, Got config path: " + m_ConfigFile);
									bFind = true;
									break;
								}
							}

							if (dr.FullName == dr.Root.FullName) //已经到了顶层
								break;
							dr = dr.Parent;
						}

						if ((!bFind) || (!File.Exists(m_ConfigFile)))
						{
							m_ConfigFile = Path.Combine("c:\\iflyweb_config\\", Path.GetFileName(configFile));
						}
					}

					if (!File.Exists(m_ConfigFile))
					{
						if (!File.Exists(m_ConfigFile + ".missing"))
						{
							string configDir = Path.GetDirectoryName(m_ConfigFile);
							if(!Directory.Exists(configDir))
								Directory.CreateDirectory(configDir);
							File.Create(m_ConfigFile + ".missing");
						}
						m_ConfigFile = "";
					}
                }

                return m_ConfigFile;
            }
            set
            {
                m_ConfigFile = value;
            }
        }
        #endregion

        public static string GetAppSetting(string section, string key, string defValue)
        {
            if (ConfigFile == "")
                return defValue;

            StaticDust.Configuration.AppSettingsReader appReader = CustomConfigurationSettings.AppSettings(ConfigFile, section);
            if (appReader == null)
                return defValue;

            string value = appReader[key] as string;
            if (string.IsNullOrEmpty(value))
                return defValue;

            return value;
        }

        public static string GetAppSetting(string key, string defValue)
        {
            return GetAppSetting(CustomConfigurationSettings.DEF_SECTION_NAME, key, defValue);
        }
    }
}
