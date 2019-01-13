using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.ComponentHelpers
{
    public class ButtonHelper
    {
               
        public static void ClickButton(IWebElement element)
        {
            element.Click();
        }
        public static bool IsButtonEnabled(IWebElement element)
        {
            return element.Enabled;
        }
        public static string GetButtonText(IWebElement element)
        {
            if (element.GetAttribute("value") == null)
            {
                return string.Empty;
            }
            else
            {
                return element.GetAttribute("value");
            }
        }
    }
}
