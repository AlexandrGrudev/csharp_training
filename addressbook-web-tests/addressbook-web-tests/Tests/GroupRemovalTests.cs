using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupRemovalTests : AutoTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Application.Groups.Remove(1);
        }
    }
}