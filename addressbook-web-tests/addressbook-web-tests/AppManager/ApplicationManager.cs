using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests.AppManager
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseUrl;

        protected LoginHelper LoginHelper;
        protected NavigationHelper NavigationHelper;
        protected GroupHelper GroupHelper;
        protected ContactHelper ContactHelper;

        private static readonly ThreadLocal<ApplicationManager> App = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver(@"C:\Windows\SysWOW64");
            baseUrl = "http://localhost/addressbook";

            LoginHelper = new LoginHelper(this);
            NavigationHelper = new NavigationHelper(this);
            GroupHelper = new GroupHelper(this);
            ContactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            Auth.Logout();
            
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public IWebDriver Driver => driver;
        public string BaseUrl => baseUrl;

        public LoginHelper Auth => LoginHelper;
        public NavigationHelper Navigator => NavigationHelper;
        public GroupHelper Groups => GroupHelper;
        public ContactHelper Contacts => ContactHelper;

        public static ApplicationManager GetInstance()
        {
            if (!App.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                App.Value = newInstance;
                newInstance.Navigator.OpenHomePage();
            }

            return App.Value;
        }
    }
}