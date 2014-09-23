using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace XeroUITest.PageObjects.Dashboard
{
    public class Header : PageObject
    {
        private IWebElement _dashboardButton;

        [FindsBy(How = How.Id, Using = "Accounts")]
        private IWebElement _accountsOptions;

        private IWebElement _reportsOptions;

        private IWebElement _adviserOptions;

        private IWebElement _contactsOptions;

        private IWebElement _settingsOptions;

        public Header(IWebDriver driver) : base(driver) { }

        public AccountsDropdown OpenAccountsDropdown()
        {
            _accountsOptions.Click();
            return PageFactory.InitElements<AccountsDropdown>(Driver);
        }
    }
}
