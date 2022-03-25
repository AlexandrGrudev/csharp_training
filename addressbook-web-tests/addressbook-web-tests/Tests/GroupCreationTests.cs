using System.Collections.Generic;
using System.IO;
using addressbook_web_tests.Model;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            var groups = new List<GroupData>();

            for (var i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            var groups = new List<GroupData>();
            var lines = File.ReadAllLines(@"groups.csv");
            
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }

        [Test, TestCaseSource(nameof(GroupDataFromFile))]
        public void GroupCreationTest(GroupData groupData)
        {
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