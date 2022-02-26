using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactModificationTests : AutoTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var newContactData = new ContactData("ccc", "last name1")
            {
                Email = "email1"
            };

            Application.Contacts.Modify(1, newContactData);
        }
    }
}