using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Web.Script.Serialization;

namespace EasyFileTransfer.Utils
{
    public class AppConfigs
    {

        string _savePath;
        public string SavePath
        {
            get
            {
                return _savePath;
            }
            set
            {
                _savePath = value;
            }
        }

        string _serverIP;
        public string ServerIP
        {
            get
            {
                return _serverIP;
            }
            set
            {
                _serverIP = value;
            }
        }

        string _domainUsername;
        public string DomainUsername
        {
            get
            {
                return _domainUsername;
            }
            set
            {
                _domainUsername = value;
            }
        }

        public static AppConfigs Load()
        {
            JavaScriptSerializer _serializer = new JavaScriptSerializer();

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings["AppConfigs"] != null && settings["AppConfigs"].Value != "")
            {
                return (AppConfigs)_serializer.Deserialize(settings["AppConfigs"].Value, typeof(AppConfigs));
            }
            return new AppConfigs();
        }

        public static void Save(AppConfigs conf)
        {
            JavaScriptSerializer _serializer = new JavaScriptSerializer();
            AddOrUpdateAppSettings("AppConfigs", _serializer.Serialize(conf));
        }

        static void AddOrUpdateAppSettings(string key, string value)
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
               
            }
        }
    }
}
