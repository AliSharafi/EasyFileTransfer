using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace EasyFileTransfer.Utils
{
    public class AppConfigs
    {
        [Category("Client Settings")]
        [Description("Where to save files that server sends to me?")]
        public string SavePath
        {
            get
            {
                return ConfigurationManager.AppSettings["SavePath"]; 
            }
            set
            {
                AddOrUpdateAppSettings("SavePath", value);
            }
        }
        [Category("Client Settings")]
        [Description("Server IP address ")]
        public string ServerIP
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerIP"];
            }
            set
            {
                AddOrUpdateAppSettings("ServerIP", value);
            }
        }


        Dictionary<string, string> _test = new Dictionary<string, string>();

        public Dictionary<string, string> Test
        {
            get
            {
                
                return _test;
            }
            set
            {
                _test = value;
            }
        }

        void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
