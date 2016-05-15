using AuScGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPoc.PocTest.Config
{
    class TestSettings : BaseSetings
    {
        private static TestSettings defaultInstance = new TestSettings();
        private static string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
        private static string settingsFile;
                
        public static TestSettings Default
        {
            get
            {
                settingsFile = Path.Combine(settingsFilePath, "TestSettings.xml");
                return defaultInstance;
            }

        }

        string browser = "InternetExplorer";
        public string Browser
        {
            get
            {
                string value = GetValue(settingsFile, "Browser");
                if (null != value)
                {
                    url = value;
                }
                return url;
                //return ((string)(this["Url"]));
            }
            //set
            //{
            //    this["Url"] = value;
            //}
        }

       
        string url = "";
        public string Url
        {
            get
            {
                string value = GetValue(settingsFile, "Url");
                if (null != value)
                {
                    url = value;
                }
                return url;
                //return ((string)(this["Url"]));
            }
            //set
            //{
            //    this["Url"] = value;
            //}
        }

        string auurl = "";
        public string AUUrl
        {
            get
            {
                string value = GetValue(settingsFile, "AUDigitalUrl");
                if (null != value)
                {
                    auurl = value;
                }
                return auurl;                
            }            
        }

        string aiurl = "";
        public string AIUrl
        {
            get
            {
                string value = GetValue(settingsFile, "AIDigitalUrl");
                if (null != value)
                {
                    aiurl = value;
                }
                return aiurl;
            }
        }

        string suurl = "";
        public string SUUrl
        {
            get
            {
                string value = GetValue(settingsFile, "SUDigitalUrl");
                if (null != value)
                {
                    suurl = value;
                }
                return suurl;
            }
        }

        string BMCurl = "";
        public string BMCUrl
        {
            get
            {
                string value = GetValue(settingsFile, "BMCDigitalUrl");
                if (null != value)
                {
                    BMCurl = value;
                }
                return BMCurl;
            }
        }

        string dBConnection = "";
        public string DBConnection
        {
            get
            {
                string value = GetValue(settingsFile, "DBConnection");
                if (null != value)
                {
                    dBConnection = value;
                }
                return dBConnection;
                //return ((string)(this["DBConnection"]));
            }
            //set
            //{
            //    this["DBConnection"] = value;
            //}
        }

        
        string getByFilterAPI = "";
        public string GetByFilterAPI
        {
            get
            {
                string value = GetValue(settingsFile, "GetByFilterAPI");
                if (null != value)
                {
                    getByFilterAPI = value;
                }
                return getByFilterAPI;
                //return ((string)(this["GetByFilterAPI"]));
            }
            //set
            //{
            //    this["GetByFilterAPI"] = value;
            //}
        }

        //[global::System.Configuration.DefaultSettingValueAttribute("False")]
        bool userViewMode = false;
        public bool UserViewMode
        {
            get
            {
                string value = GetValue(settingsFile, "UserViewMode");
                if (null != value)
                {
                    userViewMode = value.ToLower().Contains("true");

                }
                return userViewMode;
                //return ((bool)(this["UserViewMode"]));
            }
            //set
            //{
            //    this["UserViewMode"] = value;
            //}
        }

        public string BinaryPath
        {
            get
            {
                return GetValue(settingsFile, "BinaryPath");
            }
        }

    }
}
