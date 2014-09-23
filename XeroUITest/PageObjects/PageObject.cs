using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics.CodeAnalysis;

namespace XeroUITest.PageObjects
{
    public abstract class PageObject
    {
        protected IWebDriver Driver { get; set; }

        public PageObject(IWebDriver driver)
        {
            Driver = driver;
            WaitForPageToBeLoaded();
        }

        protected void WaitForPageToBeLoaded()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
