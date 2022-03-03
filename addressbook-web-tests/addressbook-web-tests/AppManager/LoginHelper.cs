using addressbook_web_tests.Model;
using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager appManager) : base(appManager)
        {
        }

        public void Login(AccountData accountData)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(accountData))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("user"), accountData.Username);
            Type(By.Name("pass"), accountData.Password);
            Driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                Driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public bool IsLoggedIn(AccountData accountData)
        {
            return IsLoggedIn() && Driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text ==
                   $"({accountData.Username})";
        }
    }
}