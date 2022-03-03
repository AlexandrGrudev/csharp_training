using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            var contactData = new ContactData("first name", "last name")
            {
                Email = "email"
            };

            Application.Contacts.Create(contactData);
        }
    }
}