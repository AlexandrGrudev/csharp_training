using System.Collections.Generic;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            var contacts = new List<ContactData>();

            for (var i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Email = GenerateRandomString(30)
                });
            }

            return contacts;
        }

        [Test, TestCaseSource(nameof(RandomContactDataProvider))]
        public void ContactCreationTest(ContactData contactData)
        { 
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