using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using ATF.Windows.Control;

namespace ATF.Windows.Client
{
    public class Application
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private static WindowsDriver<WindowsElement> _windowDriver;
        public static string ApplicationTitle => _windowDriver.Title;

        private Application()
        {
            
        }
        public static Application Launch(string applicationPathOrId,string commandLineArguments)
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", applicationPathOrId);
            appiumOptions.AddAdditionalCapability("appArguments", commandLineArguments);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            _windowDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
            _windowDriver.Manage().Window.Maximize();
            return new Application();
        }

        public WinControl GetAppControl()
        {
            var winControlInitializer = new WinControl(_windowDriver);
            var appControl = winControlInitializer.GetControl(new ControlIdentifier { Name = ApplicationTitle });
            return appControl;
        }

        public static void Close()
        {
            if (_windowDriver != null)
            {
                try
                {
                    _windowDriver.Close();
                    _windowDriver.Quit();
                }
                catch (Exception)
                {
                    _windowDriver = null;
                }
            }
        }
    }
}
