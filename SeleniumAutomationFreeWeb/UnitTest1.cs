using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomationFreeWeb
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com");
            IWebElement SignInButton = driver.FindElement(By.XPath("//*[@title='Log in to your customer account']"));
            SignInButton.Click();
            IWebElement UserEmail = driver.FindElement(By.XPath("//input[@id='email']"));
            System.Threading.Thread.Sleep(2000);
            IWebElement UserPassword = driver.FindElement(By.XPath("//input[@id='passwd']"));
            System.Threading.Thread.Sleep(2000);
            UserEmail.SendKeys("ashutosh555@gmail.com");
            UserPassword.SendKeys("Password_777");
        }
    }
}
