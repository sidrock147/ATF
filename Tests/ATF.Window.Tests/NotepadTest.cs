using ATF.Windows.Client;
using ATF.Windows.Common;
using ATF.Windows.Control;
using NUnit.Framework;

namespace ATF.Window.Tests
{
    [TestFixture]
    public class NotepadTest:TestBase
    {
        protected override string ApplicationPathOrId => @"C:\Windows\System32\notepad.exe";
        private WinControl _notepadEditor;

        public override void Setup()
        {
            base.Setup();
            _notepadEditor = AppControl.GetControl(Notepad.Editor);
        }

        [Test]
        public void EnterText()
        {
            _notepadEditor.EnterText("TestingABCDE 12345");
            Assert.AreEqual(_notepadEditor.Text, "TestingABCDE 12345");
        }

        [Test]
        public void TestKeyboardShortcuts()
        {
            _notepadEditor.EnterText("123");
            _notepadEditor.Click();
            Utilities.SendKeys("^{a}");
            Utilities.SendKeys("^{c}");
            Utilities.SendKeys("^{v 4}");
            Assert.AreEqual(_notepadEditor.Text, "123123123123");
        }

        [Test]
        public void TestMenuOperation()
        {
            _notepadEditor.EnterText("ABC");
            Notepad.MenuOperations.SelectAll(AppControl);
            Notepad.MenuOperations.Copy(AppControl);
            Notepad.MenuOperations.Paste(AppControl);
            Notepad.MenuOperations.Paste(AppControl);
            Assert.AreEqual(_notepadEditor.Text, "ABCABC");
        }

        public override void TearDown()
        {
            // Select all text and delete to clear the edit box
            _notepadEditor.Click();
            Utilities.SendKeys("^{a}");
            Utilities.SendKeys("{DEL}");
            
        }

        public override void OneTimeTearDown()
        {
            try
            {
                // Dismiss Save dialog if it is blocking the exit
                AppControl.GetControl(Notepad.Close).Click();
                AppControl.GetControl(Notepad.DontSave).Click();
            }
            catch
            {
                // ignored
            }

            base.OneTimeTearDown();
        }

    }
}
