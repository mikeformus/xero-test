using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xero.Api.Core.Model;

namespace XeroAPITest
{
    /// <summary>
    /// Tests are executed against Demo Company (NZ)
    /// </summary>
    [TestClass]
    public class OrganisationTest : BaseApiTest
    {     
        /// <summary>
        /// Verify that valid organisation entity can be requested from the server
        /// </summary>
        [TestMethod]
        public void ValidOrganisationInfoCanBeRequestedTest()
        {
            Organisation organisation = Api.Organisation;
            Assert.IsNotNull(organisation, "");
        }

        /// <summary>
        /// Verify that organisation entity is marked as Demo organisation
        /// </summary>
        [TestMethod]
        public void OrganisationMarkedAsDemoTest()
        {
            Organisation organisation = Api.Organisation;
            Assert.IsTrue((bool)organisation.IsDemoCompany, "Demo Organisation was not marked as Demo");
        }

    }
}
