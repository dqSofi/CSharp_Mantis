using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantiss_Tests
{
    public class ProjectRemoveTests : AuthTestBase
    {
        [SetUp]
        public void CheckIfProjectExists()
        {
            if (!app.Project.IsProjectExist())
            {
                app.Project.CreateNewProject(new ProjectData("ImGonnaBeDeletedSoon"));
            }
        }

        [Test]
        public void ProjectRemoveTest()
        {
            List<ProjectData> oldProjects = ProjectData.GetAllFromDB();
            ProjectData toBeRemoved = oldProjects[0];
            app.Project.Remove(toBeRemoved);
            
            List<ProjectData> newProjects = ProjectData.GetAllFromDB();

            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
