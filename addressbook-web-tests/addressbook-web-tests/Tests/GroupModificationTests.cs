using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class GroupModificationTests : AutoTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newGroupData = new GroupData("name1")
            {
                Header = "header1",
                Footer = "footer1"
            };

            Application.Groups.Modify(1, newGroupData);
        }
    }
}
