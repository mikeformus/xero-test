using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using System;
using XeroUITest.Constants;
using XeroUITest.PageObjects;
using XeroUITest.PageObjects.Dashboard;

namespace XeroUITest
{
    [TestClass]
    public class RepeatingInvoicesTest : BaseUITest
    {
        private static RepeatingInvoicesPage _repeatinginvoicesPage;

        [ClassInitialize]
        public static void NavigateToRepeatinInvoicesComponent(TestContext context)
        {
            var landingPage = PageFactory.InitElements<LandingPage>(Driver);
            var loginPage = landingPage.OpenLoginPage();
            var dashboard = loginPage.LoginWithValidCredentials(EmailAddress, Password);
            var salesPage = dashboard.Header.OpenAccountsDropdown().selectSales();
            _repeatinginvoicesPage = salesPage.openRepeatingInvoicesPage();
        }

        /// <summary>
        ///  Verify that 'Repeating' tab is displayed by default
        /// </summary>
        [TestMethod]
        public void RepeatingTabIsDisplayedByDefaultTest()
        {
            Assert.IsTrue(_repeatinginvoicesPage.IsRepeatingTabDisplayed(), "Reapiting invoices tab was not disaplyed by default on Repeating Invoices page.");
        }

        /// <summary>
        /// Verify that user is able to create new repeating invoice and that it is present in a table afterwards
        /// </summary>
        [TestMethod]
        public void UserCanCreateNewRepeatingInvoiceTest()
        {
            var invoiceDate = DateTime.Today.AddDays(3).ToString("dd MMM yyyy");
            var dueDateDay = 1;
            var invoiceState = InvoiceStateEnum.APPROVED;
            var invoiceRecipient = Guid.NewGuid().ToString("N");
            var description = Guid.NewGuid().ToString("N");

            var newRepeatingInvoicePage = _repeatinginvoicesPage.openNewInvoicePage();
            newRepeatingInvoicePage.SetInvoiceDate(invoiceDate);
            newRepeatingInvoicePage.SetDueDate(dueDateDay);
            newRepeatingInvoicePage.SelectInvoiceState(invoiceState);
            newRepeatingInvoicePage.SetInvoiceTo(invoiceRecipient);
            newRepeatingInvoicePage.AddDescription(0, description);

            _repeatinginvoicesPage = newRepeatingInvoicePage.Save();

            var entryIndex = _repeatinginvoicesPage.FindInvoiceTableIndexByName(invoiceRecipient);
            Assert.IsTrue(entryIndex >= 0, "Created invoice didn't appear in repeating invoices table.");
            Assert.AreEqual(invoiceDate, _repeatinginvoicesPage.GetInvoiceDate(entryIndex), "Incorrect invoice date appeared in repeating invoices table.");
            Assert.AreEqual(invoiceState, _repeatinginvoicesPage.GetInvoiceState(entryIndex), "Incorrect invoice state appeared in repeating invoices table.");
        }

        /// <summary>
        /// Verify that user is able to delete repeating invoice and that is is removed from table
        /// </summary>
        [TestMethod]
        public void UserCanDeleteRepeatingInvoiceTest()
        {
            var invoiceRecipient = Guid.NewGuid().ToString("N");
            var invoiceState = InvoiceStateEnum.APPROVED;

            var newRepeatingInvoicePage = _repeatinginvoicesPage.openNewInvoicePage();
            _repeatinginvoicesPage = newRepeatingInvoicePage.AddNewRepeatingInvoice(invoiceRecipient, invoiceState);
            var entryIndex = _repeatinginvoicesPage.FindInvoiceTableIndexByName(invoiceRecipient);

            var invoicesCountBeforeDelete = _repeatinginvoicesPage.CountInvoices();
            _repeatinginvoicesPage.DeleteInvoice(entryIndex);

            Assert.IsTrue((invoicesCountBeforeDelete - _repeatinginvoicesPage.CountInvoices()) == 1, "Invoice was either not removed from the table or more that one invoice was removed.");
        }

        [ClassCleanup]
        public static void DeleteAllInvoices()
        {
            _repeatinginvoicesPage.DeleteAllInvoices();
            Driver.Quit();
        }
    }
}
