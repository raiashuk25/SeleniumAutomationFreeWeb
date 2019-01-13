using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb
{
    public interface IConfig 
    {
        BrowserType GetBrowser();
        String GetUserName();
        String GetPassword();
        String GetWebsite();
        int GetPageLoadTimeout();
        int GetElementLoadTimeOut();

    }
}
