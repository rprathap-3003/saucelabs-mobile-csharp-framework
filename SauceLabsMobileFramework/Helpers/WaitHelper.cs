using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceLabsMobileFramework.Helpers
{
    public class WaitHelper
    {
        private readonly AppiumDriver _driver;
        private readonly TimeSpan _defaultTimeout;

        public WaitHelper(AppiumDriver driver, int timeoutInSeconds = 15)
        {
            _driver = driver;
            _defaultTimeout = TimeSpan.FromSeconds(timeoutInSeconds);
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            var wait = new WebDriverWait(_driver, _defaultTimeout);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForElementClickable(By locator)
        {
            var wait = new WebDriverWait(_driver, _defaultTimeout);
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool WaitForElementInvisible(By locator)
        {
            var wait = new WebDriverWait(_driver, _defaultTimeout);
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
