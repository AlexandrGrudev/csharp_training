using LinqToDB;

namespace addressbook_web_tests.Model
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups => GetTable<GroupData>();
        public ITable<ContactData> Contacts => GetTable<ContactData>();
        public ITable<GroupContactRelation> GCR => GetTable<GroupContactRelation>();
    }
}
