using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactCreationTests : AutoTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();

            var contactData = new ContactData("first name", "last name")
            {
                Email = "email"
            };

            FillContactForm(contactData);
            ReturnToHomePage();
            Logout();
        }
    }
}