using ATF.Windows.Control;

namespace ATF.Windows.Client
{
    public class Calculator
    {
        public static ControlIdentifier CalResult = new ControlIdentifier { AutomationId = "CalculatorResults"};

        public class Number
        {
            public static ControlIdentifier One = new ControlIdentifier { AutomationId = "num1Button" };
            public static ControlIdentifier Two = new ControlIdentifier { Name = "Two" };
            public static ControlIdentifier Three = new ControlIdentifier { XPath = "//Button[@Name='Three']" };
            public static ControlIdentifier Four = new ControlIdentifier { Name = "Four" };
            public static ControlIdentifier Nine = new ControlIdentifier {XPath = "//Button[@Name='Nine']"};
        }

        public class Operator
        {
            public static ControlIdentifier Plus = new ControlIdentifier { Name = "Plus" };
            public static ControlIdentifier Minus = new ControlIdentifier { Name = "Minus" };
            public static ControlIdentifier Divide = new ControlIdentifier {AutomationId = "divideButton" };
            public static ControlIdentifier Multiply = new ControlIdentifier {XPath = "//Button[@Name='Multiply by']" };
            public static ControlIdentifier Equal = new ControlIdentifier { Name = "Equals" };
        }
    }
}
