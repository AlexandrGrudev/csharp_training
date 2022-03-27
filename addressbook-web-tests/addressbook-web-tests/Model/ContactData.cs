using System;
using System.Text.RegularExpressions;

namespace addressbook_web_tests.Model
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _allEmails;

        public ContactData()
        {
        }

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
            var result = "";
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
            {
                result += $"{FirstName} {LastName}\r\n";
            }

            if (!string.IsNullOrEmpty(Address))
            {
                result += $"{Address}\r\n\r\n";
            }

            if ((!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName)) && (string.IsNullOrEmpty(Address)))
            {
                result += "\r\n";
            }

            if (!string.IsNullOrEmpty(HomePhone))
            {
                result += $"H: {HomePhone}\r\n";
            }

            if (!string.IsNullOrEmpty(MobilePhone))
            {
                result += $"M: {MobilePhone}\r\n";
            }

            if (!string.IsNullOrEmpty(WorkPhone))
            {
                result += $"W: {WorkPhone}\r\n";
            }

            if ((!string.IsNullOrEmpty(HomePhone)) || (!string.IsNullOrEmpty(MobilePhone)) || (!string.IsNullOrEmpty(WorkPhone)))
            {
                result += "\r\n";
            }

            if (!string.IsNullOrEmpty(Email))
            {
                result += $"{Email}\r\n";
            }

            if (!string.IsNullOrEmpty(Email2))
            {
                result += $"{Email2}\r\n";
            }

            if (!string.IsNullOrEmpty(Email3))
            {
                result += $"{Email3}\r\n";
            }

            Console.WriteLine("after converting: " + result);
            return result.Trim();
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