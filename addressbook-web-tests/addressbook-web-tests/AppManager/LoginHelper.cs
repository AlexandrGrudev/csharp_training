using addressbook_web_tests.Model;
using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(IWebDriver driver) : base (driver)
        {
        }

        public void Login(AccountData accountData)
        {
            Driver.FindElement(By.Name("user")).Click();
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(accountData.Username);
            Driver.FindElement(By.Name("pass")).Click();
            Driver.FindElement(By.Name("pass")).Clear();
            Driver.FindElement(By.Name("pass")).SendKeys(accountData.Password);
            Driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            Driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}