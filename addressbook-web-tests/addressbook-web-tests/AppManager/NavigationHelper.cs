using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseUrl;
        public NavigationHelper(ApplicationManager appManager) : base(appManager)
        {
            _baseUrl = appManager.BaseUrl;
        }

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        public void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            Driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}