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
            var groupData = new GroupData("name")
            {
                Header = "header",
                Footer = "footer"
            };

            Application.Groups.Create(groupData);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            Application.Groups.Create(groupData);
        }
    }
}