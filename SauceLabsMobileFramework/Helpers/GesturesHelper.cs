using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Interactions;

namespace SauceLabsMobileFramework.Helpers
{
    public class GesturesHelper
    {
        private readonly AppiumDriver _driver;

        public GesturesHelper(AppiumDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Swipes from center to top (Scroll Down)
        /// </summary>
        public void SwipeUp()
        {
            var size = _driver.Manage().Window.Size;
            int startX = size.Width / 2;
            int startY = (int)(size.Height * 0.8);
            int endY = (int)(size.Height * 0.2);

            PerformSwipe(startX, startY, startX, endY);
        }

        /// <summary>
        /// Swipes from center to bottom (Scroll Up)
        /// </summary>
        public void SwipeDown()
        {
            var size = _driver.Manage().Window.Size;
            int startX = size.Width / 2;
            int startY = (int)(size.Height * 0.2);
            int endY = (int)(size.Height * 0.8);

            PerformSwipe(startX, startY, startX, endY);
        }

        private void PerformSwipe(int startX, int startY, int endX, int endY)
        {
            PointerInputDevice touchDevice = new PointerInputDevice(PointerKind.Touch, "finger");
            var sequence = new ActionSequence(touchDevice, 0);

            sequence.AddAction(touchDevice.CreatePointerMove(CoordinateOrigin.Viewport, startX, startY, TimeSpan.Zero));
            sequence.AddAction(touchDevice.CreatePointerDown(PointerButton.TouchContact));
            sequence.AddAction(touchDevice.CreatePointerMove(CoordinateOrigin.Viewport, endX, endY, TimeSpan.FromMilliseconds(600)));
            sequence.AddAction(touchDevice.CreatePointerUp(PointerButton.TouchContact));

            _driver.PerformActions(new List<ActionSequence> { sequence });
        }
    }
}
