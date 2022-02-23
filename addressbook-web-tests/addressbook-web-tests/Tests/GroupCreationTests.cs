using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupCreationTests : AutoTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();

            var groupData = new GroupData("name")
            {
                Header = "header",
                Footer = "footer"
            };
            FillGroupForm(groupData);

            Submit();
            ReturnToGroupsPage();
            Logout();
        }
    }
}