using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using addressbook_web_tests.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
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

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader("groupsData.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText("groupsData.json"));
        }

        [Test, TestCaseSource(nameof(GroupDataFromXmlFile))]
        public void GroupCreationTest(GroupData groupData)
        {
            var oldGroupsList = GroupData.GetAllGroups();

            Application.Groups.Create(groupData);

            var newGroupsList = GroupData.GetAllGroups();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
        }

        [Test]
        public void DBConnectivityTest()
        {
            var start = DateTime.Now;
            var listFromUI = Application.Groups.GetGroupList();
            var end = DateTime.Now;
            Console.WriteLine("UI " + end.Subtract(start));

            start = DateTime.Now;
            GroupData.GetAllGroups();
            end = DateTime.Now;
            Console.WriteLine("DB " + end.Subtract(start));
        }
    }
}