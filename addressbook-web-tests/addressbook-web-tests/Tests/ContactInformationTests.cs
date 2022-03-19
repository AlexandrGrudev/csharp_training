using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            var dataFromTable = Application.Contacts.GetContactInformationFromTable(0);
            var dataFromForm = Application.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(dataFromTable, dataFromForm);
            Assert.AreEqual(dataFromTable.Address, dataFromForm.Address);
            Assert.AreEqual(dataFromTable.AllPhones, dataFromForm.AllPhones);
            Assert.AreEqual(dataFromTable.AllEmails, dataFromForm.AllEmails);
        }

        [Test]
        public void DetailContactInformationTest()
        {
            var dataFromEditForm = Application.Contacts.GetContactInformationFromEditForm(0);
            var dataFromDetails = Application.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(dataFromEditForm.ConvertDataToString(), dataFromDetails);
        }
    }
}
