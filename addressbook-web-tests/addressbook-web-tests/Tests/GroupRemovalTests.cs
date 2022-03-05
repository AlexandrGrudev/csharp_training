using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Application.Groups.CreateGroupIfNeedeed();
            Application.Groups.Remove(1);
        }
    }
}