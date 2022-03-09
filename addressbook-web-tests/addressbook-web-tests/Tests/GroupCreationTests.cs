using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            var groupData = new GroupData("name")
            {
                Header = "header",
                Footer = "footer"
            };

            var oldGroupsList = Application.Groups.GetGroupList();

            Application.Groups.Create(groupData);

            var newGroupsList = Application.Groups.GetGroupList();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            var oldGroupsList = Application.Groups.GetGroupList();

            Application.Groups.Create(groupData);

            var newGroupsList = Application.Groups.GetGroupList();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            var groupData = new GroupData("'name")
            {
                Header = "",
                Footer = ""
            };

            var oldGroupsList = Application.Groups.GetGroupList();

            Application.Groups.Create(groupData);

            var newGroupsList = Application.Groups.GetGroupList();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}