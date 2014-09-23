using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace XeroUITest.PageObjects.Dashboard
{
    public class MainDashboard : PageObject
    {
        private Header _header;

        public MainDashboard(IWebDriver driver) : base(driver) { }

        public Header Header
        {
            get { return _header ?? (_header = PageFactory.InitElements<Header>(Driver)); }        
        }
    }
}
