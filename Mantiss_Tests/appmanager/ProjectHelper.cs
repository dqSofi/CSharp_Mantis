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
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.LinkText("Manage Projects")).Count > 0);
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
