using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;
        //private bool _acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            _driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            _baseUrl = "http://localhost/addressbook";
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", _verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();

            GroupData groupData = new GroupData("name");
            groupData.Header = "header";
            groupData.Footer = "footer";
            FillGroupForm(groupData);

            Submit();
            ReturnToGroupsPage();
            Logout();
        }

        private void Logout()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Submit()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData groupData)
        {
            _driver.FindElement(By.Name("group_name")).Click();
            _driver.FindElement(By.Name("group_name")).Clear();
            _driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            _driver.FindElement(By.Name("group_header")).Click();
            _driver.FindElement(By.Name("group_header")).Clear();
            _driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            _driver.FindElement(By.Name("group_footer")).Click();
            _driver.FindElement(By.Name("group_footer")).Clear();
            _driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
        }

        private void InitGroupCreation()
        {
            _driver.FindElement(By.XPath("//div[@id='content']/form/input[4]")).Click();
        }

        private void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData accountData)
        {
            _driver.FindElement(By.Name("user")).Click();
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(accountData.Username);
            _driver.FindElement(By.Name("pass")).Click();
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(accountData.Password);
            _driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
        }

/*
        private bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
*/

/*
        private bool IsAlertPresent()
        {
            try
            {
                _driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
*/

/*
        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (_acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                _acceptNextAlert = true;
            }
        }
*/
    }
}
