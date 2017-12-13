using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace Mantiss_Tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account,ProjectData project, IssueData issue)
        {
            Mantiss.MantisConnectPortTypeClient client =
            new Mantiss.MantisConnectPortTypeClient();
                //Mantiss.MantisConnectPortTypeClient client =
                //new Mantiss.MantisConnectPortTypeClient();
            Mantiss.IssueData issueM = new Mantiss.IssueData();
            issueM.summary = issue.Summary;
            issueM.description = issue.Description;
            issueM.category = issue.Category;
            issueM.project = new Mantiss.ObjectRef();
            issueM.project.id = project.ID;
            client.mc_issue_add(account.Name, account.Password, issueM);
        }
    }
}
