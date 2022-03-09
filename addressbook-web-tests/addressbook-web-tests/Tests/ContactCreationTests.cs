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
            
            var oldContactsList = Application.Contacts.GetContactList();
            
            Application.Contacts.Create(contactData);

            var newContactList = Application.Contacts.GetContactList();
            oldContactsList.Add(contactData);
            oldContactsList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactsList, newContactList);
        }
    }
}