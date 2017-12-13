using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Mantiss_Tests
{
    public class ProjectHelper :HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public bool IsProjectExist()
        {
            OpenManage();
            OpenManageProjects();
            return IsElementPresent(By.XPath("//table/tbody/tr/td/a"));
        }

        public void CreateNewProject(ProjectData project)
        {
            OpenManage();
            OpenManageProjects();
            OpenCreateNewProject();
            SetProjectName(project.Name);
            SubmitAddProject();
        }

        private void OpenManage()
        {
            driver.FindElement(By.XPath("(//span[contains(text(),'Manage')])")).Click();
            //By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.LinkText("Manage Projects")).Count > 0);
        }

        public void Remove(ProjectData toBeRemoved)
        {
            OpenManage();
            OpenManageProjects();
            SelectProject(toBeRemoved.Name);
            ClickDeleteProjectButton();
            ConfirmDeleteProject();
        }

        private void ConfirmDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        private void ClickDeleteProjectButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.XPath("(//p[contains(text(),'Are you sure you want to delete this project')])")).Count > 0);
        }

        private void SelectProject(string name)
        {
            driver.FindElement(By.XPath("//a[.='"+name+"']")).Click();
        }

        private void OpenManageProjects()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.XPath("//button[@type='submit']")).Count > 0);
        }

        private void OpenCreateNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        private void SetProjectName(string name)
        {
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(name);
        }

        private void SubmitAddProject()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }
    }
}
