using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ATF.Windows.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace ATF.Windows.Control
{
    public class WinControl
    {
        private static WindowsDriver<WindowsElement> _windowsDriver;
        internal AppiumWebElement WindowsWebElement;

        public WinControl(WindowsDriver<WindowsElement> windowsDriver)
        {
            _windowsDriver = windowsDriver;
        }
        internal WinControl(AppiumWebElement winWebElement)
        {
            WindowsWebElement = winWebElement;
        }

        public bool IsDisplayed => WindowsWebElement.Displayed;

        public bool IsEnabled => WindowsWebElement.Enabled;

        public bool IsSelected => WindowsWebElement.Selected;

        public string Text => WindowsWebElement.Text;

        public string TagName => WindowsWebElement.TagName;

        public Point Location => WindowsWebElement.Location;

        public string AttributeValue(string attributeName)
        {
            return WindowsWebElement.GetAttribute(attributeName);
        }

        public void Click()
        {
            ControlAction.Click(this);
        }

        public void DoubleClick()
        {
            ControlAction.DoubleClick(this);
        }

        public void ContextClick()
        {
            ControlAction.ContextClick(this);
        }

        public void ClickMenuItem()
        {
            ControlAction.ClickMenuItem(this);
        }

        public void EnterText(string text)
        {
            ControlAction.EnterText(this, text);
        }

        public WinControl GetControl(ControlIdentifier controlIdentifier, int maxTries = 30, int waitBetweenTries = 50)
        {
            var searchBy = SearchBy(controlIdentifier);
            var control = RetryHelper.TryGetUntil(() =>
                WindowsWebElement == null
                    ? _windowsDriver.FindElement(searchBy)
                    : WindowsWebElement.FindElement(searchBy),maxTries,waitBetweenTries);
            return CreateControlObject(control);
        }

        public IEnumerable<WinControl> GetControls(ControlIdentifier controlIdentifier, int maxTries = 30, int waitBetweenTries = 50)
        {
            var searchBy = SearchBy(controlIdentifier);
            var collection = RetryHelper.TryGetUntil(() => WindowsWebElement == null
                ? (IEnumerable<AppiumWebElement>)_windowsDriver.FindElements(searchBy)
                : WindowsWebElement.FindElements(searchBy),maxTries,waitBetweenTries);
            return collection.Select(CreateControlObject).ToList();
        }

        public WinControl CreateControlObject(AppiumWebElement windowElement)
        {
            return new WinControl(windowElement);
        }

        internal static Actions GetDriverAction()
        {
            return new Actions(_windowsDriver);
        }

        private static By SearchBy(ControlIdentifier controlIdentifier)
        {
            var searchBy = By.Id(string.Empty);
            if (!string.IsNullOrEmpty(controlIdentifier.AutomationId))
            {
                searchBy = new ByAccessibilityId(controlIdentifier.AutomationId);
            }
            else if (!string.IsNullOrEmpty(controlIdentifier.Name))
            {
                searchBy = By.Name(controlIdentifier.Name);
            }
            else if (!string.IsNullOrEmpty(controlIdentifier.ClassName))
            {
                searchBy = By.ClassName(controlIdentifier.ClassName);

            }
            else if (!string.IsNullOrEmpty(controlIdentifier.ControlType))
            {
                searchBy = By.TagName(controlIdentifier.ControlType);

            }
            else if (!string.IsNullOrEmpty(controlIdentifier.XPath))
            {
                searchBy = By.XPath(controlIdentifier.XPath);
            }
            else if (!string.IsNullOrEmpty(controlIdentifier.LinkText))
            {
                searchBy = By.LinkText(controlIdentifier.LinkText);
            }
            else if (!string.IsNullOrEmpty(controlIdentifier.PartialLinkText))
            {
                searchBy = By.PartialLinkText(controlIdentifier.PartialLinkText);
            }

            return searchBy;
        }

    }
}
