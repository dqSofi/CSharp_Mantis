using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantiss_Tests
{
    public class AddNewIssueTests :TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData("administrator", "admin");
            IssueData issueData = new IssueData()
            {
                Summary = "Summary",
                Description = "Description",
                Category = "General"
            };
            ProjectData project = new ProjectData() {
                ID = "3"
            };
            app.API.CreateNewIssue(account, project,issueData);

        }

        [Test]
        public void API_AddProject()
        {
            AccountData account = new AccountData("administrator", "admin");
            List<ProjectData> oldProjects = app.API.GetProjectsList(account);
            //проверка на существоание проекта с таким именем, в случае совпадения имен
            //добавляется рандомные символы в конец названия
            ProjectData project = new ProjectData("newP");
            for (int i = 0; i < oldProjects.Count; i++)
                        {
                            if (project.Name == oldProjects[i].Name)
                            {
                                project.Name = project.Name + GenerateRandomString(2);
                            }
                        };
            System.Console.Out.WriteLine(project.Name);
            app.API.AddProject(account, project);
            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
