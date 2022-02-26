using addressbook_web_tests.AppManager;
using addressbook_web_tests.Model;
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
            Application.Navigator.OpenHomePage();
            Application.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            Application.Auth.Logout();
            Application.Stop();
        }
    }
}