using ATF.Windows.Control;

namespace ATF.Windows.Client
{
    public class Notepad
    {
        public static ControlIdentifier Editor = new ControlIdentifier {ClassName = "Edit" };
        public static ControlIdentifier Close = new ControlIdentifier {Name = "Close"};
        public static ControlIdentifier DontSave = new ControlIdentifier {Name = "Don't Save" };


        public class MenuOperations
        {
            public static void SelectAll(WinControl parentControl) => SelectMenuItem(parentControl, "Edit", "Select All");

            public static void Paste(WinControl parentControl) => SelectMenuItem(parentControl, "Edit", "Paste");

            public static void Copy(WinControl parentControl) => SelectMenuItem(parentControl, "Edit", "Copy");

            private static void SelectMenuItem(WinControl parentControl, params string[] menuItems)
            {
                foreach (var menuItem in menuItems)
                {
                    parentControl.GetControl(new ControlIdentifier { XPath = $"//MenuItem[starts-with(@Name, \"{menuItem}\")]" }).ClickMenuItem();
                }
            }
        }
    }
}
