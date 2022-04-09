using System.Linq;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            var group = GroupData.GetAllGroups()[0];
            var oldList = group.GetContacts();
            var contact = ContactData.GetAllContacts().Except(oldList).First();

            Application.Contacts.AddContactToGroup(contact, group);

            var newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
