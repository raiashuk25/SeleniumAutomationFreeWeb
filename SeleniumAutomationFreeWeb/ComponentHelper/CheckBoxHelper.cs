using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.ComponentHelpers
{
    public class CheckBoxHelper
    {
        public static void CheckedCheckBox(IWebElement element)
        {
            element.Click();
        }
        public static bool IsCheckedBoxChecked(IWebElement element)
        {
            string flag = element.GetAttribute("checked");
            if (flag == null)
            {
                return false;
            }
            else
            {
                return flag.Equals(true) || flag.Equals("checked");
            }
        }
    }
}
