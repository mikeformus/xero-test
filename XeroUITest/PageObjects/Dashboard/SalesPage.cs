using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using XeroUITest.PageObjects.Dashboard;

namespace XeroUITest.PageObjects
{
    public class SalesPage : PageObject
    {
        [FindsBy(How = How.CssSelector, Using = "a[href*='SearchRepeating']")]
        IWebElement _repeatingInvoicesLink;

        public SalesPage(IWebDriver driver) : base(driver) { }

        public RepeatingInvoicesPage openRepeatingInvoicesPage()
        {
            _repeatingInvoicesLink.Click();
            return PageFactory.InitElements<RepeatingInvoicesPage>(Driver);
        }
    }
}
