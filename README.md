# C# Mobile Automation Framework for SauceLabs

A production-ready C# (.NET 8.0) mobile automation framework using NUnit and Appium WebDriver, integrated with SauceLabs Real Device Cloud. Supports both **Native** (iOS/Android) and **Mobile Web** (Safari/Chrome) applications.

## Prerequisites
- .NET 8.0 SDK
- SauceLabs Account (Username & Access Key)

## Project Structure
- `Base/`: Contains `DriverFactory` (handles W3C capabilities for SauceLabs) and `BaseTest`.
- `Config/`: Configuration reader for `appsettings.json`.
- `Helpers/`: `WaitHelper` for explicit waits and `GesturesHelper` for Swipes.
- `Pages/`: Abstract `BasePage` and examples for Native & Web pages.
- `Tests/`: NUnit Test Fixtures parameterized to run on both iPhone and Samsung.

## Configuration
Update `SauceLabsMobileFramework/Config/appsettings.json` with your SauceLabs credentials:
```json
{
  "SauceLabs": {
    "Username": "YOUR_SAUCE_USERNAME",
    "AccessKey": "YOUR_SAUCE_ACCESS_KEY"
  }
}
```

## Running Tests
Run the tests using the .NET CLI:
```bash
cd SauceLabsMobileFramework
dotnet test
```

Tests will automatically update their Pass/Fail status in the SauceLabs dashboard.
