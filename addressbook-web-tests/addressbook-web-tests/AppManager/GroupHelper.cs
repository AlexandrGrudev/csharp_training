using addressbook_web_tests.Model;
using OpenQA.Selenium;

namespace addressbook_web_tests.AppManager
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager appManager) : base (appManager)
        {
        }

        public GroupHelper Create(GroupData groupData)
        {
            AppManager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            AppManager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper Modify(int index, GroupData newGroupData)
        {
            AppManager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            ModifySelectedGroup();
            FillGroupForm(newGroupData);
            SubmitGroupModification();
            AppManager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper Remove(int index)
        {
            AppManager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveSelectedGroups();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            Driver.FindElement(By.XPath("//div[@id='content']/form/input[4]")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);

            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            Driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            Driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        public GroupHelper ModifySelectedGroup()
        {
            Driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper RemoveSelectedGroups()
        {
            Driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper CreateGroupIfNeedeed()
        {
            if (!IsElementPresent(By.ClassName("group")))
            {
                Create(new GroupData("test group"));
            }

            return this;
        }
    }
}