using NUnit.Framework;
using SauceLabsMobileFramework.Base;
using SauceLabsMobileFramework.Pages;
using System;

namespace SauceLabsMobileFramework.Tests
{
    [TestFixture("iPhone")]
    [TestFixture("Samsung")]
    public class NativeAppTests : BaseTest
    {
        private string _deviceType;

        public NativeAppTests(string deviceType)
        {
            _deviceType = deviceType;
        }

        [SetUp]
        public void SetUp()
        {
            SetupDriver(_deviceType, isNativeApp: true);
        }

        [Test]
        public void VerifyInvalidLoginNativeApp()
        {
            NativeAppPage loginPage = new NativeAppPage(Driver);
            loginPage.Login("locked_out_user", "secret_sauce");

            string error = loginPage.GetErrorMessage();
            Assert.IsTrue(error.Contains("Sorry, this user has been locked out"), 
                "Error message did not match expected text");
        }
    }
}
