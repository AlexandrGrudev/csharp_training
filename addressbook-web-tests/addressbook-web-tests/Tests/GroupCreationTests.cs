using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupCreationTests : AutoTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            Application.Navigator.OpenHomePage();
            Application.Auth.Login(new AccountData("admin", "secret"));
            Application.Navigator.GoToGroupsPage();
            Application.Groups.InitGroupCreation();

            var groupData = new GroupData("name")
            {
                Header = "header",
                Footer = "footer"
            };
            Application.Groups.FillGroupForm(groupData);

            Application.Groups.SubmitGroupCreation();
            Application.Navigator.ReturnToGroupsPage();
            Application.Auth.Logout();
        }
    }
}