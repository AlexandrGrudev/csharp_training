using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests.AppManager
{
    public class ApplicationManager
    {
        protected IWebDriver Driver;
        protected string BaseUrl;

        protected LoginHelper LoginHelper;
        protected NavigationHelper NavigationHelper;
        protected GroupHelper GroupHelper;
        protected ContactHelper ContactHelper;

        public ApplicationManager()
        {
            Driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            BaseUrl = "http://localhost/addressbook";

            LoginHelper = new LoginHelper(Driver);
            NavigationHelper = new NavigationHelper(Driver, BaseUrl);
            GroupHelper = new GroupHelper(Driver);
            ContactHelper = new ContactHelper(Driver);
        }

        public LoginHelper Auth => LoginHelper;
        public NavigationHelper Navigator => NavigationHelper;
        public GroupHelper Groups => GroupHelper;
        public ContactHelper Contacts => ContactHelper;


        public void Stop()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}