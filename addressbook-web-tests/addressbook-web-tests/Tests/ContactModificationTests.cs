using System;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var newContactData = new ContactData("ccc", "sss")
            {
                Email = "zzz"
            };

            Application.Contacts.CreateContactIfNeeded();

            var oldContactsList = ContactData.GetAllContacts();
            var toBeModified = oldContactsList[0];
            
            Application.Contacts.Modify(toBeModified, newContactData);
            var newContactList = ContactData.GetAllContacts();
            oldContactsList[0].FirstName = newContactData.FirstName;
            oldContactsList[0].LastName = newContactData.LastName;
            oldContactsList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactsList, newContactList);
        }
    }
}