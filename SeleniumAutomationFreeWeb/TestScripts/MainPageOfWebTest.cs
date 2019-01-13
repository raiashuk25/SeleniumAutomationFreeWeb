using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationFreeWeb.ComponentHelpers;
using SeleniumAutomationFreeWeb.Settings;
using SeleniumAutomationFreeWeb.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFreeWeb.TestScripts
{
    [TestClass]
    public class MainPageOfWebTest
    {

        HomePage homePage = new HomePage(ObjectRepository.Driver);
        [TestMethod]
        public void UserSignIn()
        {
            ButtonHelper.ClickButton(homePage.SignInButton);
            TextBoxHelper.ClearTextBox(homePage.UserName);
            TextBoxHelper.TypeInTextBox(homePage.UserName, ObjectRepository.Config.GetUserName());
            TextBoxHelper.TypeInTextBox(homePage.Password, ObjectRepository.Config.GetPassword());
        }

    }
}
