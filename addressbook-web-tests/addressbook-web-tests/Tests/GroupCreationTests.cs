using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using addressbook_web_tests.Model;
using Newtonsoft.Json;
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
            var xmlFilePath =
                @"C:\Users\Пользователь\source\repos\csharp_training\addressbook-web-tests\addressbook-web-tests\groupsData.xml";

            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(xmlFilePath));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            var jsonFilePath =
                @"C:\Users\Пользователь\source\repos\csharp_training\addressbook-web-tests\addressbook-web-tests\groupsData.json";

            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(jsonFilePath));
        }

        [Test, TestCaseSource(nameof(GroupDataFromJsonFile))]
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