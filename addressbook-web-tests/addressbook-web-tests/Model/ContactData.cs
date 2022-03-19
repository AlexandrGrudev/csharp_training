using System;
using System.Text.RegularExpressions;

namespace addressbook_web_tests.Model
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _allEmails;

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (_allPhones != null)
                {
                    return _allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
                
            }
            set
            {
                _allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (_allEmails != null)
                {
                    return _allEmails;
                }

                return ((ConvertToTableView(Email)) + ConvertToTableView(Email2) + ConvertToTableView(Email3)).Trim();
            }
            set
            {
                _allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }

            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

        private string ConvertToTableView(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "";
            }

            return email + "\r\n";
        }

        public string ConvertDataToString()
        {
            return $"{FirstName} {LastName}\r\n{Address}\r\n\r\nH: {HomePhone}\r\nM: {MobilePhone}\r\nW: {WorkPhone}\r\n\r\n{Email}\r\n{Email2}\r\n{Email3}";
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return "first name = " + FirstName + " last name = " + LastName;
        }
    }
}