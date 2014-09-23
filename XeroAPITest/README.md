XeroAPITest
========
This project contains solution for Task 1 of Q3. Test Automation Exercise.
It uses Xero.Api for .Net which is included here as a separate project under ThirdParty folder of solurion root directory.

XeroAPITest.OrganisationTest.cs is the class that contains test cases. Currenty there are two scenarions:
- Verify that valid organisation entity can be requested from the server
- Verify that organisation entity is marked as Demo organisation 

Tests can be executed directly from Visual Studio or using Visual Studio command line tools which are described here:
http://msdn.microsoft.com/en-us/library/ms182486.aspx

Steps to run tests from Visual Studio:
1. Open XeroTest solution.
2. Build it.
3. Go to XeroUITest project -> OrganisationTest.cs class. (optional - otherwise all tests in solution can be run at once)
4. Run tests in the current context using Main toolbar or configured shortcuts.
5. Results can be viewed either in VS or in TestResults folder of solution root directory.
