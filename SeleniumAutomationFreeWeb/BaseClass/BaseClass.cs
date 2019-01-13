using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumAutomationFreeWeb;
using SeleniumAutomationFreeWeb.ComponentHelper;
using SeleniumAutomationFreeWeb.ComponentHelpers;
using SeleniumAutomationFreeWeb.CustomExceptions;
using SeleniumAutomationFreeWeb.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.BaseClass
{
    [TestClass]
    public class BaseClass
    {
        //Drivers
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(ChromeOption());
            return driver;

        }
        private static IWebDriver GetFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        //Driver Options
        private static ChromeOptions ChromeOption()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;
        }
        //Assmbly initialization
        [AssemblyInitialize]
        public  static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFireFoxDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound("Driver not found:" + ObjectRepository.Config.GetBrowser().ToString());
            }
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }
        
        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
