using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantiss_Tests
{
    [TestFixture]
    public class NewProjectCreationTests : AuthTestBase
    {
        [Test]
        public void NewProjectCreationTest()
        {
            ProjectData project = new ProjectData("newP");
            List<ProjectData> oldProjects = ProjectData.GetAllFromDB();
            //проверка на существоание проекта с таким именем, в случае совпадения имен
            //добавляется рандомные символы в конец названия
            for (int i = 0; i < oldProjects.Count;i++)
                {
                if (project.Name == oldProjects[i].Name)
                {
                    project.Name = project.Name + GenerateRandomString(2);
                }
                }
            app.Project.CreateNewProject(project);
            List<ProjectData> newProjects = ProjectData.GetAllFromDB();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}