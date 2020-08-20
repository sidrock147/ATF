using ATF.Windows.Client;
using ATF.Windows.Control;
using NUnit.Framework;

namespace ATF.Window.Tests
{
    [TestFixture]
    public class TestBase
    {
        protected virtual string ApplicationPathOrId => string.Empty;

        protected WinControl AppControl { get; set; }
        protected virtual string CommandLineArguments => string.Empty;

        protected Application Application { get; set; }

        
        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            Application = Application.Launch(ApplicationPathOrId,CommandLineArguments);
            AppControl = Application.GetAppControl();
        }

        [SetUp]
        public virtual void Setup()
        {
            
        }

        [TearDown]
        public virtual void TearDown()
        {

        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            Application.Close();
        }
    }
}
