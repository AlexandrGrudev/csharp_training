using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            Application.Contacts.CreateContactIfNeeded();
            Application.Contacts.Remove(1);
        }
    }
}