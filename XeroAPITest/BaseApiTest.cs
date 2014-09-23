using System.Configuration;
using System.IO;
using Xero.Api.Core;
using Xero.Api.Infrastructure.OAuth;
using XeroAPITest.Authentication;

namespace XeroAPITest
{
    public class BaseApiTest
    {
        private static XeroCoreApi _api;

        protected static XeroCoreApi Api
        {
            get { return _api ?? (_api = SetupApi()); }
        }

        private static XeroCoreApi SetupApi()
        {
            return new XeroCoreApi(ConfigurationManager.AppSettings["BaseUrl"],
                new CertificateAuthenticator(Path.GetFullPath(ConfigurationManager.AppSettings["SigningCertificate"])),
                new Consumer(ConfigurationManager.AppSettings["ConsumerKey"], ConfigurationManager.AppSettings["ConsumerSecret"]),
                null);
        }
    }
}
