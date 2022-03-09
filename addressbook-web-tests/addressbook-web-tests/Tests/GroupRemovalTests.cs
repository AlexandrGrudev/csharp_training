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
            Application.Groups.Remove(0);
            
            oldGroupsList.RemoveAt(0);
            var newGroupList = Application.Groups.GetGroupList();
            Assert.AreEqual(oldGroupsList, newGroupList);
        }
    }
}