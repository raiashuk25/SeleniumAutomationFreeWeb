using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }
        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.UserName);

        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }

        public int GetPageLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout is null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeOut);
            if (timeout is null)
                return 30;
            return Convert.ToInt32(timeout);
        }
    }
}
