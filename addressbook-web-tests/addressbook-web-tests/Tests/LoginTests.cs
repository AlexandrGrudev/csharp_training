using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class LoginTests : AutoTestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            Application.Auth.Logout();

            var account = new AccountData("admin", "secret");
            Application.Auth.Login(account);

            Assert.IsTrue(Application.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            Application.Auth.Logout();

            var account = new AccountData("admin", "123");
            Application.Auth.Login(account);

            Assert.IsFalse(Application.Auth.IsLoggedIn(account));
        }
    }
}
