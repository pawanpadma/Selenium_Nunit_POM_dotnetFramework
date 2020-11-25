using NUnit.Framework;
using nunit_datadriven.pageobjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nunit_datadriven.commons
{
    [TestFixture]
    public class SetupClass
    {
        public IWebDriver driver = InitBrowser.Getbrowser();
        public HomePage home;
        public LoginPage login;
        public Read_ini read;

        [OneTimeSetUp]
        public void initApplication()
        {
            read = new Read_ini();
            home = new HomePage();
            login = new LoginPage();
            driver.Navigate().GoToUrl(ReadEnv.ReadData("base", "appUrl"));
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void loginToApp()
        {
            home.TapLoginLink();
            login.AssertLogin();
            login.loginToApplication(ReadEnv.ReadData("base", "username"), ReadEnv.ReadData("base", "password"));
        }

        [TearDown]
        public void logout()
        {
            home.logout();
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            driver.Quit();
        }
    }
}