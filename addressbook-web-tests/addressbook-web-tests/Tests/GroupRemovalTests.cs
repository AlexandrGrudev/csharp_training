using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Application.Groups.CreateGroupIfNeedeed();

            var oldGroupsList = Application.Groups.GetGroupList();
            var toBeRemoved = oldGroupsList[0];
            Application.Groups.Remove(0);
            
            oldGroupsList.RemoveAt(0);
            var newGroupList = Application.Groups.GetGroupList();
            Assert.AreEqual(oldGroupsList, newGroupList);
            foreach (var group in newGroupList)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}