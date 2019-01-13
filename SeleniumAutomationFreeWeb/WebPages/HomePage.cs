using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumAutomationFreeWeb.BaseClass;
using SeleniumAutomationFreeWeb.ComponentHelpers;
using SeleniumAutomationFreeWeb.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.WebPages
{
    [TestClass]
    public class HomePage : BasePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver _driver) : base(_driver){this.driver = _driver;}
        public IWebElement SignInButton => GenericHelper.GetElement(By.XPath("//*[@title='Log in to your customer account']"));
        public IWebElement UserName => GenericHelper.GetElement((By.XPath("//input[@id='email']")));
        public IWebElement Password => GenericHelper.GetElement((By.XPath("//input[@id='passwd']")));

    }
}
