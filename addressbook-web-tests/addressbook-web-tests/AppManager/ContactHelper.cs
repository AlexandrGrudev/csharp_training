﻿using System.Collections.Generic;
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
            Driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ ++index +"]/td[8]/a/img")).Click();
            return this;
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
    }
}