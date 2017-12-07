using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace Mantiss_Tests
{
    /// <summary>
    /// Сводное описание для NewProjectCreationTest
    /// </summary>
    [TestFixture]
    public class NewProjectCreationTests : AuthTestBase
    {
        [Test]
        public void NewProjectCreationTest()
        {
            ProjectData project = new ProjectData("project name");

            List<ProjectData> oldProjects = ProjectData.GetAllFromDB();

            app.Project.CreateNewProject(project);

            List<ProjectData> newProjects = ProjectData.GetAllFromDB();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}