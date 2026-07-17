using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using SauceLabsMobileFramework.Config;
using NUnit.Framework;

namespace SauceLabsMobileFramework.Base
{
    public class DriverFactory
    {
        public static AppiumDriver InitDriver(string deviceType, bool isNativeApp)
        {
            var deviceConfig = ConfigReader.GetDeviceConfig(deviceType);
            string platformName = deviceConfig["PlatformName"];

            AppiumOptions options = new AppiumOptions();
            options.PlatformName = platformName;
            options.AutomationName = platformName.ToLower() == "ios" ? "XCUITest" : "UiAutomator2";

            // App or Browser context
            if (isNativeApp)
            {
                options.App = deviceConfig["AppUrl"];
            }
            else
            {
                options.BrowserName = deviceConfig["BrowserName"];
            }

            // SauceLabs Specific Capabilities (W3C format)
            var sauceOptions = new Dictionary<string, object>
            {
                { "username", ConfigReader.GetSauceUsername() },
                { "accessKey", ConfigReader.GetSauceAccessKey() },
                { "name", TestContext.CurrentContext.Test.Name },
                { "build", $"Build-{DateTime.Now.ToString("yyyy-MM-dd")}" },
                { "deviceName", deviceConfig["DeviceName"] },
                { "platformVersion", deviceConfig["PlatformVersion"] },
                { "appiumVersion", deviceConfig["AppiumVersion"] }
            };

            options.AddAdditionalAppiumOption("sauce:options", sauceOptions);

            Uri hubUrl = new Uri(ConfigReader.GetSauceHubUrl());

            if (platformName.ToLower() == "ios")
            {
                return new IOSDriver(hubUrl, options, TimeSpan.FromMinutes(3));
            }
            else
            {
                return new AndroidDriver(hubUrl, options, TimeSpan.FromMinutes(3));
            }
        }
    }
}
