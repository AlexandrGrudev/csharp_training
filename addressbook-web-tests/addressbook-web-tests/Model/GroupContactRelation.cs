using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;

namespace addressbook_web_tests.Model
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name = "group_id")]
        public string GroupID { get; }
        
        [Column(Name = "id")]
        public string ContactID { get; }
    }
}
