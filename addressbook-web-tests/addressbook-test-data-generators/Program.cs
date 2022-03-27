// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using addressbook_web_tests.Model;
using addressbook_web_tests.Tests;
using Newtonsoft.Json;

var dataType = args[0];
var count = Convert.ToInt32(args[1]);
var writer = new StreamWriter(args[2]);
var format = args[3];

if (dataType == "groups")
{
    var groupsList = new List<GroupData>();

    for (var i = 0; i < count; i++)
    {
        groupsList.Add(new GroupData(AutoTestBase.GenerateRandomString(10))
        {
            Header = AutoTestBase.GenerateRandomString(100),
            Footer = AutoTestBase.GenerateRandomString(100)
        });
    }

    switch (format)
    {
        case "csv":
            WriteGroupsToCsvFile(groupsList, writer);
            break;
        case "xml":
            WriteGroupsToXmlFile(groupsList, writer);
            break;
        case "json":
            WriteGroupsToJsonFile(groupsList, writer);
            break;
        default:
            Console.WriteLine("Unrecognized format " + format);
            break;
    }
}
else if (dataType == "contacts")
{
    var contactsList = new List<ContactData>();
    for (var i = 0; i < count; i++)
    {
        contactsList.Add(new ContactData(AutoTestBase.GenerateRandomString(20), AutoTestBase.GenerateRandomString(20))
        {
            Address = AutoTestBase.GenerateRandomString(30)
        });
    }
    switch (format)
    {
        case "xml":
            WriteContactsToXmlFile(contactsList, writer);
            break;
        case "json":
            WriteContactsToJsonFile(contactsList, writer);
            break;
        default:
            Console.WriteLine("Unrecognized format " + format);
            break;
    }
}

writer.Close();

static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
{
    foreach (var group in groups)
    {
        writer.WriteLine($"{group.Name},{group.Header},{group.Footer}");
    }
}

static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
{
    new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
}

static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
{
    writer.Write(JsonConvert.SerializeObject(groups));
}

static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
{
    new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
}

static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
{
    writer.Write(JsonConvert.SerializeObject(contacts));
}