using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace XeroUITest.PageObjects
{
    public class LandingPage : PageObject
    {
        [FindsBy(How = How.CssSelector, Using = "a[data-gaaction='Login']")]
        private IWebElement _loginLink;

        public LandingPage(IWebDriver driver) : base(driver) { }

        public LoginPage OpenLoginPage()
        {
            _loginLink.Click();
            return PageFactory.InitElements<LoginPage>(Driver);
        }
    }
}
