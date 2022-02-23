using addressbook_web_tests.AppManager;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class AutoTestBase
    {
        protected ApplicationManager Application;

        [SetUp]
        public void SetupTest()
        {
            Application = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            Application.Stop();
        }
    }
}