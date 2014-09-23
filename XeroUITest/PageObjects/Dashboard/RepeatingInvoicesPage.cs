using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using XeroUITest.Constants;

namespace XeroUITest.PageObjects.Dashboard
{
    public class RepeatingInvoicesPage : PageObject
    {
        [FindsBy(How = How.CssSelector, Using = "div[class='tasks'] a[href*='RepeatTransactions/Edit']")]
        private IWebElement _newRepeatingInvoiceButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'SearchRepeating')]/..")]
        private IWebElement _repeatingTab;

        [FindsBy(How = How.CssSelector, Using = "a[onclick*='deleteSelectedItems'] span")]
        private IWebElement _deleteButton;

        [FindsBy(How = How.CssSelector, Using = "table thead input[type='checkbox']")]
        private IWebElement _selectAllCheckbox;


        private By _tableRowNameFieldLocator = By.ClassName("nav");
        private By _tableRowLocator = By.CssSelector("table tbody tr");
        private By _checkboxLocator = By.CssSelector("input[type='checkbox']");

        private int _invoiceDateColumnIndex = 6;
        private int _invoiceStateColumnIndex = 8;

        public RepeatingInvoicesPage(IWebDriver driver) : base(driver) { }

        public NewReapitingInvoicePage openNewInvoicePage()
        {
            _newRepeatingInvoiceButton.Click();
            return PageFactory.InitElements<NewReapitingInvoicePage>(Driver);
        }

        public bool IsRepeatingTabDisplayed()
        {
            return _repeatingTab.GetAttribute("class").Contains("selected");
        }

        public int FindInvoiceTableIndexByName(string invoiceRecipient)
        {
            IList<IWebElement> elements = Driver.FindElements(_tableRowNameFieldLocator);
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Text == invoiceRecipient)
                    return i;
            }

            throw new NotFoundException("Invoice with name: " + invoiceRecipient + " was not found.");
        }

        public string GetInvoiceDate(int entryIndex)
        {
            string invoiceDate = FindRowByIndex(entryIndex).FindElements(By.CssSelector("td"))[_invoiceDateColumnIndex].Text;
            return invoiceDate.Trim();
        }

        public InvoiceStateEnum GetInvoiceState(int entryIndex)
        {
            string invoiceStateValue = FindRowByIndex(entryIndex).FindElements(By.CssSelector("td"))[_invoiceStateColumnIndex].Text;

            if (invoiceStateValue.Contains("Sent"))
                return InvoiceStateEnum.APPROVED_FOR_SENDING;

            else if (invoiceStateValue.Contains("Draft"))
                return InvoiceStateEnum.SAVED_AS_DRAFT;

            else
                return InvoiceStateEnum.APPROVED;
        }

        public int CountInvoices()
        {
            return Driver.FindElements(_tableRowNameFieldLocator).Count;
        }

        public void DeleteInvoice(int index)
        {
            FindRowByIndex(index).FindElement(_checkboxLocator).Click();
            _deleteButton.Click();
            //this is where ConfirmDeletePopup object should be cretaed and used but this project becomes too large. So I'll just skip to clicking 'Ok' button.
            Driver.FindElement(By.CssSelector("div[id*='popup'] a[onclick*='Submit']")).Click();
            WaitForPageToBeLoaded();
        }

        public void DeleteAllInvoices()
        {
            if (CountInvoices() > 0)
            {
                _selectAllCheckbox.Click();
                _deleteButton.Click();
                //this is where ConfirmDeletePopup object should be cretaed and used but this project becomes too large. So I'll just skip to clicking 'Ok' button.
                Driver.FindElement(By.CssSelector("div[id*='popup'] a[onclick*='Submit']")).Click();
                WaitForPageToBeLoaded();
            }
        }

        private IWebElement FindRowByIndex(int index)
        {
            return Driver.FindElements(_tableRowLocator)[index];
        }
    }
}
