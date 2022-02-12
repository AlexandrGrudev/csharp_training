using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactCreationTests
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
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();

            var contactData = new ContactData("first name", "last name")
            {
                Email = "email"
            };

            FillContactForm(contactData);
            ReturnToHomePage();
            Logout();
        }

        private void Logout()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToHomePage()
        {
            _driver.FindElement(By.LinkText("home page")).Click();
        }

        private void FillContactForm(ContactData contactData)
        {
            _driver.FindElement(By.Name("firstname")).Click();
            _driver.FindElement(By.Name("firstname")).Clear();
            _driver.FindElement(By.Name("firstname")).SendKeys(contactData.FirstName);
            _driver.FindElement(By.Name("lastname")).Click();
            _driver.FindElement(By.Name("lastname")).Clear();
            _driver.FindElement(By.Name("lastname")).SendKeys(contactData.LastName);
            _driver.FindElement(By.Name("email")).Click();
            _driver.FindElement(By.Name("email")).Clear();
            _driver.FindElement(By.Name("email")).SendKeys(contactData.Email);
            _driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        private void InitContactCreation()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
        }

        private void OpenHomePage()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
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
