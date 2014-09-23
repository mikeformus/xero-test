using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using XeroUITest.PageObjects.Dashboard;

namespace XeroUITest.PageObjects
{
    public class LoginPage : PageObject
    {
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _email;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _password;

        [FindsBy(How = How.Id, Using = "submitButton")]
        private IWebElement _submitButton;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public MainDashboard LoginWithValidCredentials(String emailValue, String passwordValue)
        {
            _email.SendKeys(emailValue);
            _password.SendKeys(passwordValue);
            _submitButton.Click();

            return PageFactory.InitElements<MainDashboard>(Driver);
        }
    }
}
