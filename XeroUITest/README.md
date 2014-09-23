XeroUITest
========
This project contains solution for Task 2 of Q3. Test Automation Exercise.
It assumes that we already have a user that is registered and signed up for Demo NZ organisation from Xero Marketing Site.
User credentails are stored in a project App.config file along with Xero Marketing Site URL and Path to Chromedriver.exe directory.
Current solution uses following frameworks and tools:
- Microsoft.VisualStudio.TestTools.UnitTesting
- Selenium WebDriver
- WebDriver Support

As already mentioned it uses chromdriver wich is stored in ThirdParty folder of solution root directory. It assumes that we already have Chrome installed in its default location.
WebDriver frameworks are downloaded automaticaly during build process using NuGet tool. 

Page Object Pattern is used for developing test scripts. 
XeroUITest.RepeatingInvoicesTest.cs is the class that contains test cases. Currenty there are three scenarions:
- Verify that 'Repeating' tab is displayed by default
- Verify that user is able to create new repeating invoice and that it is present in a table afterwards
- Verify that user is able to delete repeating invoice and that is is removed from table

Tests can be executed directly from Visual Studio or using Visual Studio command line tools which are described here:
http://msdn.microsoft.com/en-us/library/ms182486.aspx

Steps to run tests from Visual Studio:
1. Open XeroTest solution.
2. Build it.
3. Go to XeroUITest project -> RepeatingInvoicesTest.cs class. (optional - otherwise all tests in solution can be run at once)
4. Run tests in the current context using Main toolbar or configured shortcuts.
5. Results can be viewed either in VS or in TestResults folder of solution root directory.