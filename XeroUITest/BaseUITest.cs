using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.IO;

namespace XeroUITest
{
    public class BaseUITest
    {
        private static IWebDriver _driver;
        private static string _emailAddress;
        private static string _password;

        protected static IWebDriver Driver
        {
            get { return _driver ?? (_driver = SetupDriver()); }
        }

        protected static string EmailAddress
        {
            get { return _emailAddress ?? (_emailAddress = ConfigurationManager.AppSettings["EmailAddress"]); }
        }

        protected static string Password
        {
            get { return _password ?? (_password = ConfigurationManager.AppSettings["Password"]); }
        }

        private static IWebDriver SetupDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("test-type"); //this gets rid of certificate error issue when running chrome
            var driver = new ChromeDriver(Path.GetFullPath(ConfigurationManager.AppSettings["ChromeDriverDirectory"]), options);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrl"]);
            return driver;
        }
    }
}
