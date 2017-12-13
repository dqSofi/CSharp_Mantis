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
    }
}
