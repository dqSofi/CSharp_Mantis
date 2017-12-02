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

            //получить текущий список проектов
            app.Project.CreateNewProject(project);

            //получить новый список проектов
            //добавить в старый список новый проект
            //отсортировать оба списка
            //сравнить оба списка
           

        }
    }
}
