using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                var groupsFromUI = Application.Groups.GetGroupList();
                var groupsFromDB = GroupData.GetAllGroups();
                groupsFromUI.Sort();
                groupsFromDB.Sort();
                Assert.AreEqual(groupsFromUI, groupsFromDB);
            }
        }
    }
}