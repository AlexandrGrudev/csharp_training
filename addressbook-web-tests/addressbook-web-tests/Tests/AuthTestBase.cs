using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class AuthTestBase : AutoTestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            Application.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}