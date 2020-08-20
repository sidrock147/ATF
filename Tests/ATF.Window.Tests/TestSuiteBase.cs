using NUnit.Framework;
using ATF.Windows.Common;

namespace ATF.Window.Tests
{
    [SetUpFixture]
    public class TestSuiteBase
    {
        private const string WinAppDriverProcess = "WinAppDriver";
        private const string WinAppDriverExePath = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Utilities.KillProcess(true, WinAppDriverProcess);
            Utilities.StartProcess(WinAppDriverExePath, string.Empty);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Utilities.KillProcess(true, WinAppDriverProcess);
        }
    }
}
