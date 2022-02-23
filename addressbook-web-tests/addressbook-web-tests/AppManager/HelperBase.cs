using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class HelperBase
    {
        protected IWebDriver Driver;
        public HelperBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}