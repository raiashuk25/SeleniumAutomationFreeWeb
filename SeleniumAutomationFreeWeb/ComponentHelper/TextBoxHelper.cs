using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.ComponentHelpers
{
    [TestClass]
    public class TextBoxHelper
    {
        public static void TypeInTextBox(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        public static void ClearTextBox(IWebElement element)
        {
            element.Clear();
        }
    }
}
