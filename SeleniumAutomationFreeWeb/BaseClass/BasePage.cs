using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.BaseClass
{
    public class BasePage
    {
        private IWebDriver driver;
        //constructor
        public BasePage(IWebDriver _driver) { this.driver = _driver; }
        //write commoon used methods here -- like mavigation bar etc
        public string Title
        {
            get { return driver.Title; }
        }
    }
}
