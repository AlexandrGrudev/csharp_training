using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseUrl;
        public NavigationHelper(IWebDriver driver, string baseUrl) : base(driver)
        {
            _baseUrl = baseUrl;
        }

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        public void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            Driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}