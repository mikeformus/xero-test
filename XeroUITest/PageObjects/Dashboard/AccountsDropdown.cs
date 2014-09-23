using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace XeroUITest.PageObjects
{
    public class AccountsDropdown : PageObject
    {
        [FindsBy(How = How.CssSelector, Using = "a[href*='BankAccounts']")]
        private IWebElement _bankAccountsOption;

        [FindsBy(How = How.CssSelector, Using = "a[href*='Receivable']")]
        private IWebElement _salesOption;

        [FindsBy(How = How.CssSelector, Using = "a[href*='Payable']")]
        private IWebElement _purchasesOption;

        [FindsBy(How = How.CssSelector, Using = "a[href*='Payroll']")]
        private IWebElement _payRunOption;

        [FindsBy(How = How.CssSelector, Using = "a[href*='Expenses']")]
        private IWebElement _expenseClaimsOption;

        [FindsBy(How = How.CssSelector, Using = "a[href*='FixedAssets']")]
        private IWebElement _fixedAssetsOption;

        public AccountsDropdown(IWebDriver driver) : base(driver) { }

        public SalesPage selectSales()
        {
            _salesOption.Click();
            return PageFactory.InitElements<SalesPage>(Driver);
        }
    }
}
