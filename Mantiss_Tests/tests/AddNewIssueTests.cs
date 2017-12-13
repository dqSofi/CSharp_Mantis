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
            IssueData issue = new IssueData()
            {
                Summary = "some text",
                Description = "Some long text",
                Category = "General"
            };
            ProjectData project = new ProjectData() {
                ID = "1"
            };
            app.API.CreateNewIssue(account,project,issue);

        }
    }
}
