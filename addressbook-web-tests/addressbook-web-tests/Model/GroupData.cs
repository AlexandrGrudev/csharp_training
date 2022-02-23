namespace addressbook_web_tests.Model
{
    public class GroupData
    {
        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public GroupData(string name)
        {
            Name = name;
        }
    }
}