using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using XeroUITest.Constants;

namespace XeroUITest.PageObjects.Dashboard
{
    public class NewReapitingInvoicePage : PageObject
    {
        [FindsBy(How = How.Id, Using = "StartDate")]
        private IWebElement _startDate;

        [FindsBy(How = How.Id, Using = "DueDateDay")]
        private IWebElement _dueDateDay;

        [FindsBy(How = How.CssSelector, Using = "input[value='draft']")]
        private IWebElement _saveAsDraftRadio;

        [FindsBy(How = How.CssSelector, Using = "input[value='approved']")]
        private IWebElement _approveRadio;

        [FindsBy(How = How.CssSelector, Using = "input[value='approvedAndEmailed']")]
        private IWebElement _approveForSendingRadio;

        [FindsBy(How = How.CssSelector, Using = "input[id*='PaidToName'][id*='value']")]
        private IWebElement _setInvoiceToInput;

        [FindsBy(How = How.CssSelector, Using = "button[onclick*='Save']")]
        private IWebElement _saveButton;

        private By _descriptionLocator = By.CssSelector("div[class*='Description'][class*='cell']");

        public NewReapitingInvoicePage(IWebDriver driver) : base(driver) { }

        public void SetInvoiceDate(String dateTime)
        {
            _startDate.Clear();
            _startDate.SendKeys(dateTime);
        }

        public void SetDueDate(int dayOfTheMonth)
        {
            _dueDateDay.Clear();
            _dueDateDay.SendKeys(dayOfTheMonth.ToString());
        }

        public void SelectInvoiceState(InvoiceStateEnum invoiceStateEnum)
        {
            switch (invoiceStateEnum)
            {
                case InvoiceStateEnum.SAVED_AS_DRAFT: _saveAsDraftRadio.Click();
                    break;
                case InvoiceStateEnum.APPROVED: _approveRadio.Click();
                    break;
                case InvoiceStateEnum.APPROVED_FOR_SENDING: _approveForSendingRadio.Click();
                    break;
            }
        }

        public void SetInvoiceTo(string invoiceRecipient)
        {
            _setInvoiceToInput.Clear();
            _setInvoiceToInput.SendKeys(invoiceRecipient);
        }

        public void AddDescription(int row, String description)
        {
            IWebElement descriptionElement = Driver.FindElements(_descriptionLocator)[row];
            descriptionElement.Click();
            new Actions(Driver).SendKeys(description).Build().Perform();
        }

        public RepeatingInvoicesPage Save()
        {
            _saveButton.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Invoices"));
            return PageFactory.InitElements<RepeatingInvoicesPage>(Driver);
        }

        internal RepeatingInvoicesPage AddNewRepeatingInvoice(string invoiceRecipient, InvoiceStateEnum invoiceState)
        {
            var invoiceDate = DateTime.Today.AddMonths(1).ToString("dd MMM yyyy");
            var dueDateDay = 1;
            var description = Guid.NewGuid().ToString("N");

            SelectInvoiceState(invoiceState);
            SetInvoiceTo(invoiceRecipient);
            AddDescription(0, description);
            SetInvoiceDate(invoiceDate);
            SetDueDate(dueDateDay);

            return Save();
        }
    }
}
