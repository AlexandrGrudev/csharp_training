using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newGroupData = new GroupData("name1")
            {
                Header = "header1",
                Footer = "footer1"
            };

            Application.Groups.CreateGroupIfNeedeed();
            var oldGroupsList = Application.Groups.GetGroupList();

            Application.Groups.Modify(1, newGroupData);

            var newGroupsList = Application.Groups.GetGroupList();
            oldGroupsList[1].Name = newGroupData.Name;
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}