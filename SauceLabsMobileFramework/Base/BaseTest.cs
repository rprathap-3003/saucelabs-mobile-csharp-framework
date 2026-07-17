using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace SauceLabsMobileFramework.Base
{
    public class BaseTest
    {
        protected AppiumDriver Driver { get; private set; }

        public void SetupDriver(string deviceType, bool isNativeApp)
        {
            try
            {
                Driver = DriverFactory.InitDriver(deviceType, isNativeApp);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to initialize {deviceType} driver: {ex.Message}");
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                // Send result to SauceLabs
                bool passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
                try
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:job-result={(passed ? "passed" : "failed")}");
                }
                catch (Exception)
                {
                    // Ignore exception if Javascript executor fails (e.g., driver crashed)
                }
                finally
                {
                    Driver.Quit();
                }
            }
        }
    }
}
