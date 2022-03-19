using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using addressbook_web_tests.Model;
using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager appManager) : base(appManager)
        {
        }

        public ContactHelper Create(ContactData contactData)
        {
            InitContactCreation();
            FillContactForm(contactData);
            AppManager.Navigator.ReturnToHomePage();

            return this;
        }

        public ContactHelper Modify(int index, ContactData newContactData)
        {
            AppManager.Navigator.OpenHomePage();
            InitContactModification(index);
            FillContactForm(newContactData);
            SubmitContactModification();
            AppManager.Navigator.ReturnToHomePage();

            return this;
        }

        public void Remove(int index)
        {
            AppManager.Navigator.OpenHomePage();
            SelectContact(index);
            RemoveSelectedContacts();
            SubmitContactRemoval();
            AppManager.Navigator.OpenHomePage();
        }

        public ContactHelper InitContactCreation()
        {
            Driver.FindElement(By.LinkText("add new")).Click();

            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            //Driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ ++index +"]/td[8]/a/img")).Click();
            Driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
            return this;
        }

        private void OpenDetailContactInformation(int index)
        {
            Driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();
        }

        public ContactHelper SelectContact(int index)
        {
            Driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ ++index +"]/td/input")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("email"), contactData.Email);
            Driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveSelectedContacts()
        {
            Driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            Driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactRemoval()
        {
            Driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper CreateContactIfNeeded()
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[2]")))
            { 
                Create(new ContactData("FirstName", "LastName"));
            }

            return this;
        }

        private List<ContactData> contactCache;

        public List<ContactData> GetContactList()
        {
            if (this.contactCache == null)
            {
                AppManager.Navigator.OpenHomePage();

                contactCache = new List<ContactData>();

                var rows = Driver.FindElements(By.Name("entry"));
                foreach (var element in rows)
                {
                    var columns = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new ContactData(columns[2].Text, columns[1].Text));
                }
            }

            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            AppManager.Navigator.OpenHomePage();
            InitContactModification(index);

            var firstName = Driver.FindElement(By.Name("firstname")).GetAttribute("value");
            var lastName = Driver.FindElement(By.Name("lastname")).GetAttribute("value");
            var address = Driver.FindElement(By.Name("address")).GetAttribute("value");

            var homePhone = Driver.FindElement(By.Name("home")).GetAttribute("value");
            var mobilePhone = Driver.FindElement(By.Name("mobile")).GetAttribute("value");
            var workPhone = Driver.FindElement(By.Name("work")).GetAttribute("value");

            var email = Driver.FindElement(By.Name("email")).GetAttribute("value");
            var email2 = Driver.FindElement(By.Name("email2")).GetAttribute("value");
            var email3 = Driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address, HomePhone = homePhone, MobilePhone = mobilePhone, WorkPhone = workPhone,
                Email = email, Email2 = email2, Email3 = email3
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            AppManager.Navigator.OpenHomePage();
            var cells = Driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            var lastName = cells[1].Text;
            var firstName = cells[2].Text;
            var address = cells[3].Text;
            var allPhones = cells[5].Text;
            var allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address, AllPhones = allPhones, AllEmails = allEmails
            };
        }
        
        public string GetContactInformationFromDetails(int index)
        {
            AppManager.Navigator.OpenHomePage();
            OpenDetailContactInformation(index);

            var information = Driver.FindElement(By.Id("content")).Text;
            Console.WriteLine(information);
            return information;
        }

        public int GetNumberOfSearchResults()
        {
            AppManager.Navigator.OpenHomePage();
            var text = Driver.FindElement(By.TagName("label")).Text;
            var match = new Regex(@"\d+").Match(text);
            return Int32.Parse(match.Value);
        }
    }
}