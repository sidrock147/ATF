namespace ATF.Windows.Control
{
    public class ControlAction
    {
        public static void Click(WinControl control)
        {
            control.WindowsWebElement.Click();
        }

        public static void DragAndDrop(WinControl sourceControl, WinControl targetControl)
        {
            WinControl.GetDriverAction().ClickAndHold(sourceControl.WindowsWebElement).MoveByOffset(50,50).MoveToElement(targetControl.WindowsWebElement).Release().Perform();
        }

        public static void ContextClick(WinControl control)
        {
            WinControl.GetDriverAction().ContextClick(control.WindowsWebElement).Perform();
        }

        public static void ClickMenuItem(WinControl control)
        {
            WinControl.GetDriverAction().Click(control.WindowsWebElement).Perform();
        }

        public static void DoubleClick(WinControl control)
        {
            WinControl.GetDriverAction().DoubleClick(control.WindowsWebElement).Perform();
        }

        public static void EnterText(WinControl control, string text)
        {
            control.WindowsWebElement.SendKeys(text);
        }

    }
}
