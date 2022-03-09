using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            Application.Contacts.CreateContactIfNeeded();

            var oldContactsList = Application.Contacts.GetContactList();

            Application.Contacts.Remove(1);

            var newContactsList = Application.Contacts.GetContactList();
            oldContactsList.RemoveAt(0);
            oldContactsList.Sort();
            newContactsList.Sort();
            Assert.AreEqual(oldContactsList, newContactsList);
        }
    }
}