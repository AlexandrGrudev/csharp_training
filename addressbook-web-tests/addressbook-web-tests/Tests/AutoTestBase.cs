using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests.Tests
{
    public class AutoTestBase
    {
        protected IWebDriver Driver;
        private StringBuilder _verificationErrors;
        protected string BaseUrl;

        [SetUp]
        public void SetupTest()
        {
            Driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            BaseUrl = "http://localhost/addressbook";
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", _verificationErrors.ToString());
        }

        protected void Login(AccountData accountData)
        {
            Driver.FindElement(By.Name("user")).Click();
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(accountData.Username);
            Driver.FindElement(By.Name("pass")).Click();
            Driver.FindElement(By.Name("pass")).Clear();
            Driver.FindElement(By.Name("pass")).SendKeys(accountData.Password);
            Driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        protected void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        protected void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void InitGroupCreation()
        {
            Driver.FindElement(By.XPath("//div[@id='content']/form/input[4]")).Click();
        }

        protected void InitContactCreation()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void FillGroupForm(GroupData groupData)
        {
            Driver.FindElement(By.Name("group_name")).Click();
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            Driver.FindElement(By.Name("group_header")).Click();
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            Driver.FindElement(By.Name("group_footer")).Click();
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
        }

        protected void FillContactForm(ContactData contactData)
        {
            Driver.FindElement(By.Name("firstname")).Click();
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(contactData.FirstName);
            Driver.FindElement(By.Name("lastname")).Click();
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(contactData.LastName);
            Driver.FindElement(By.Name("email")).Click();
            Driver.FindElement(By.Name("email")).Clear();
            Driver.FindElement(By.Name("email")).SendKeys(contactData.Email);
            Driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        protected void ReturnToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void ReturnToHomePage()
        {
            Driver.FindElement(By.LinkText("home page")).Click();
        }

        protected void Submit()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }

        protected void Logout()
        {
            Driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}