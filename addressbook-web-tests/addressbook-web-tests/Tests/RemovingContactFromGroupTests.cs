using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroupTest()
        {
            var group = GroupData.GetAllGroups()[0];
            var oldContactsList = group.GetContacts();
            var contact = oldContactsList[0];

            Application.Contacts.RemoveContactFromGroup(contact, group);

            var newContactsList = group.GetContacts();
            oldContactsList.Remove(contact);
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
        }
    }
}