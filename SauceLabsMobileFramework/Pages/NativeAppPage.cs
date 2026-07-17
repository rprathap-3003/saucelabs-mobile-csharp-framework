using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SauceLabsMobileFramework.Pages
{
    public class NativeAppPage : BasePage
    {
        public NativeAppPage(AppiumDriver driver) : base(driver) { }

        // Locators using MobileBy for native context
        private By UsernameField => MobileBy.AccessibilityId("test-Username");
        private By PasswordField => MobileBy.AccessibilityId("test-Password");
        private By LoginButton => MobileBy.AccessibilityId("test-LOGIN");
        private By ErrorMessage => MobileBy.XPath("//*[@content-desc='test-Error message' or @name='test-Error message']");

        public void Login(string username, string password)
        {
            Type(UsernameField, username);
            Type(PasswordField, password);
            Click(LoginButton);
        }

        public string GetErrorMessage()
        {
            return GetText(ErrorMessage);
        }
    }
}
