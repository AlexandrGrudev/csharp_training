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
            var xmlFilePath =
                @"C:\Users\Пользователь\source\repos\csharp_training\addressbook-web-tests\addressbook-web-tests\contactsData.xml";

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(xmlFilePath));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            var jsonFilePath =
                @"C:\Users\Пользователь\source\repos\csharp_training\addressbook-web-tests\addressbook-web-tests\contactsData.json";

            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(jsonFilePath));
        }

        [Test, TestCaseSource(nameof(ContactDataFromJsonFile))]
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