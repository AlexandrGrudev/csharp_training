using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            Application.Contacts.CreateContactIfNeeded();

            var oldContactsList = ContactData.GetAllContacts();
            var toBeRemoved = oldContactsList[1];

            Application.Contacts.Remove(toBeRemoved);

            var newContactsList = ContactData.GetAllContacts();
            oldContactsList.RemoveAt(0);
            oldContactsList.Sort();
            newContactsList.Sort();
            Assert.AreEqual(oldContactsList, newContactsList);
        }
    }
}