using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactCreationTests : AutoTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            Application.Navigator.OpenHomePage();
            Application.Auth.Login(new AccountData("admin", "secret"));
            Application.Contacts.InitContactCreation();

            var contactData = new ContactData("first name", "last name")
            {
                Email = "email"
            };

            Application.Contacts.FillContactForm(contactData);
            Application.Navigator.ReturnToHomePage();
            Application.Auth.Logout();
        }
    }
}