using ATF.Windows.Client;
using ATF.Windows.Control;
using NUnit.Framework;

namespace ATF.Window.Tests
{
    [TestFixture]
    public class CalculatorTest:TestBase
    {
        protected override string ApplicationPathOrId => "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        public override void Setup()
        {
            base.Setup();
            AppControl.GetControl(new ControlIdentifier { Name = "Clear" }).Click();
        }

       [Test]
        public void AddNumbers()
        {
            AppControl.GetControl(Calculator.Number.One).Click();
            AppControl.GetControl(Calculator.Operator.Plus).Click();
            AppControl.GetControl(Calculator.Number.Four).Click();
            AppControl.GetControl(Calculator.Operator.Equal).Click();
            Assert.AreEqual("5", GetCalculatorResult(AppControl));
        }

        [Test]
        public void SubtractNumbers()
        {
            AppControl.GetControl(Calculator.Number.Four).Click();
            AppControl.GetControl(Calculator.Operator.Minus).Click();
            AppControl.GetControl(Calculator.Number.Two).Click();
            AppControl.GetControl(Calculator.Operator.Equal).Click();
            Assert.AreEqual("2", GetCalculatorResult(AppControl));
        }

        [Test]
        public void MultiplyNumbers()
        {
            AppControl.GetControl(Calculator.Number.Three).Click();
            AppControl.GetControl(Calculator.Operator.Multiply).Click();
            AppControl.GetControl(Calculator.Number.Two).Click();
            AppControl.GetControl(Calculator.Operator.Equal).Click();
            Assert.AreEqual("6", GetCalculatorResult(AppControl));
        }

        [Test]
        public void DivideNumbers()
        {
            AppControl.GetControl(Calculator.Number.Nine).Click();
            AppControl.GetControl(Calculator.Operator.Divide).Click();
            AppControl.GetControl(Calculator.Number.Three).Click();
            AppControl.GetControl(Calculator.Operator.Equal).Click();
            Assert.AreEqual("3", GetCalculatorResult(AppControl));
        }

        [TestCase("One", "Plus", "Two", "3")]
        [TestCase("Nine", "Minus", "One", "8")]
        [TestCase("Eight", "Divide by", "Eight", "1")]
        public void AllOperations(string num1, string operation, string num2, string expectedResult)
        {
            AppControl.GetControl(CreateIdentifierByName(num1)).Click();
            AppControl.GetControl(CreateIdentifierByName(operation)).Click();
            AppControl.GetControl(CreateIdentifierByName(num2)).Click();
            AppControl.GetControl(Calculator.Operator.Equal).Click();
            Assert.AreEqual(expectedResult, GetCalculatorResult(AppControl));
        }

        string GetCalculatorResult(WinControl parentControl)
        {
            return parentControl.GetControl(Calculator.CalResult).Text.Replace("Display is", string.Empty).Trim();
        }

        static ControlIdentifier CreateIdentifierByName(string text) => new ControlIdentifier {Name = text };
    }
}
