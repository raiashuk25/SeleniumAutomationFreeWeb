using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationFreeWeb.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.ComponentHelpers
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By locator)
        {
            try
            {
                //Works for unique elements
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
            {
                return ObjectRepository.Driver.FindElement(locator);
            }
            else if(IsElementPresent(locator)==false)
            {
                WaitForWebElement(locator, TimeSpan.FromMilliseconds(15000));
                return ObjectRepository.Driver.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException("Element not found :" + locator.ToString());

            }
        }
        public static bool WaitForWebElement(By locatar, TimeSpan timeOut)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeOut);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(WaitForWebElementFunc(locatar));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            return flag;
        }
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locatar)
        {
            return ((x) =>
            {
                if (x.FindElements(locatar).Count == 1)
                    return true;
                return false;
            });
        }
        public static IWebElement WaitForWebElementInPage(By locatar, TimeSpan timeOut)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeOut);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(WaitForWebElementInPageFunc(locatar));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            return flag;
        }
        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locatar)
        {
            return ((x) =>
            {
                if (x.FindElements(locatar).Count == 1)
                    return x.FindElement(locatar);
                return null;
            });
        }
        public static void TakeScreenShot(string filename = "Screen")
        {
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyyMM-dd-mm-ss") + ".jpg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                return;
            }
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        }
    }
}
