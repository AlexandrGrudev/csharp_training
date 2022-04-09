using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                var contactsFromUI = Application.Contacts.GetContactList();
                var contactsFromDB = ContactData.GetAllContacts();
                contactsFromUI.Sort();
                contactsFromDB.Sort();
                Assert.AreEqual(contactsFromUI, contactsFromDB);
            }
        }
    }
}