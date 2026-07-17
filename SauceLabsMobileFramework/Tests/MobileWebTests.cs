using NUnit.Framework;
using SauceLabsMobileFramework.Base;
using SauceLabsMobileFramework.Pages;

namespace SauceLabsMobileFramework.Tests
{
    [TestFixture("iPhone")]
    [TestFixture("Samsung")]
    public class MobileWebTests : BaseTest
    {
        private string _deviceType;

        public MobileWebTests(string deviceType)
        {
            _deviceType = deviceType;
        }

        [SetUp]
        public void SetUp()
        {
            SetupDriver(_deviceType, isNativeApp: false);
        }

        [Test]
        public void VerifyGoogleSearchMobileWeb()
        {
            WebAppPage webPage = new WebAppPage(Driver);
            
            webPage.NavigateTo("https://www.google.com");
            webPage.Search("SauceLabs Mobile Automation");

            string resultTitle = webPage.GetFirstResultTitle();
            Assert.IsNotEmpty(resultTitle, "Search results should not be empty");
        }
    }
}
