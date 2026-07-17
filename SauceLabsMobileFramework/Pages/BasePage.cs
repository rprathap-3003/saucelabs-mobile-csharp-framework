using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SauceLabsMobileFramework.Helpers;

namespace SauceLabsMobileFramework.Pages
{
    public abstract class BasePage
    {
        protected AppiumDriver Driver;
        protected WaitHelper Wait;
        protected GesturesHelper Gestures;

        public BasePage(AppiumDriver driver)
        {
            Driver = driver;
            Wait = new WaitHelper(driver);
            Gestures = new GesturesHelper(driver);
        }

        protected void Click(By locator)
        {
            Wait.WaitForElementClickable(locator).Click();
        }

        protected void Type(By locator, string text)
        {
            var element = Wait.WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return Wait.WaitForElementVisible(locator).Text;
        }

        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
