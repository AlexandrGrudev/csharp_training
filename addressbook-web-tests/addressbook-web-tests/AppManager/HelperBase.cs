using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class HelperBase
    {
        protected IWebDriver Driver;
        protected ApplicationManager AppManager;
        public HelperBase(ApplicationManager appManager)
        {
            this.AppManager = appManager;
            Driver = appManager.Driver;
        }
    }
}