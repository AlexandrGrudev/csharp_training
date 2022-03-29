using System;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var newContactData = new ContactData("ccc", "sss")
            {
                Email = "zzz"
            };

            Application.Contacts.CreateContactIfNeeded();

            var oldContactsList = Application.Contacts.GetContactList();

            Application.Contacts.Modify(1, newContactData);
            var newContactList = Application.Contacts.GetContactList();
            oldContactsList[1].FirstName = newContactData.FirstName;
            oldContactsList[1].LastName = newContactData.LastName;
            oldContactsList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactsList, newContactList);
        }
    }
}