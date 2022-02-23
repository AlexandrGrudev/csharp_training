using addressbook_web_tests.Model;
using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base (driver)
        {
        }

        public void InitGroupCreation()
        {
            Driver.FindElement(By.XPath("//div[@id='content']/form/input[4]")).Click();
        }

        public void FillGroupForm(GroupData groupData)
        {
            Driver.FindElement(By.Name("group_name")).Click();
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            Driver.FindElement(By.Name("group_header")).Click();
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            Driver.FindElement(By.Name("group_footer")).Click();
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
        }

        public void SubmitGroupCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }
    }
}