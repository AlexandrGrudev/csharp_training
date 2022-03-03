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

        protected void Type(By locator, string text)
        {
            if (text != null)
            {
                Driver.FindElement(locator).Click();
                Driver.FindElement(locator).Clear();
                Driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}