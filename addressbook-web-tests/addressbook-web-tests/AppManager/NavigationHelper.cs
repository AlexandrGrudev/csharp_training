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
            if (Driver.Url == _baseUrl)
            {
                return;
            }

            Driver.Navigate().GoToUrl(_baseUrl);
        }

        public void GoToGroupsPage()
        {
            if (Driver.Url == _baseUrl + "/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }

            Driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToHomePage()
        {
            Driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}