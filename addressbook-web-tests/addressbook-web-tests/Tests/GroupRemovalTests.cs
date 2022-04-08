using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Application.Groups.CreateGroupIfNeedeed();

            var oldGroupsList = GroupData.GetAllGroups();
            var toBeRemoved = oldGroupsList[0];
            Application.Groups.Remove(toBeRemoved);
            
            oldGroupsList.RemoveAt(0);
            var newGroupList = GroupData.GetAllGroups();
            Assert.AreEqual(oldGroupsList, newGroupList);
            foreach (var group in newGroupList)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}