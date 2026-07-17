using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SauceLabsMobileFramework.Pages
{
    public class WebAppPage : BasePage
    {
        public WebAppPage(AppiumDriver driver) : base(driver) { }

        // Locators using standard By for web context
        private By SearchBox => By.Name("q");
        private By FirstResult => By.CssSelector("div#search h3");

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Search(string query)
        {
            var searchInput = Wait.WaitForElementVisible(SearchBox);
            searchInput.Clear();
            searchInput.SendKeys(query);
            searchInput.SendKeys(Keys.Enter);
        }

        public string GetFirstResultTitle()
        {
            return GetText(FirstResult);
        }
    }
}
