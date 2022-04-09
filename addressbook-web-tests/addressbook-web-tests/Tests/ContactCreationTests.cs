using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using addressbook_web_tests.Model;
using Newtonsoft.Json;
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

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader("contactsData.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText("contactsData.json"));
        }

        [Test, TestCaseSource(nameof(ContactDataFromJsonFile))]
        public void ContactCreationTest(ContactData contactData)
        {
            var oldContactsList = ContactData.GetAllContacts();
            
            Application.Contacts.Create(contactData);

            var newContactList = ContactData.GetAllContacts();
            oldContactsList.Add(contactData);
            oldContactsList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactsList, newContactList);
        }
    }
}