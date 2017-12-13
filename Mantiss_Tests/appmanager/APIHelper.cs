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

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantiss.MantisConnectPortTypeClient client 
                = new Mantiss.MantisConnectPortTypeClient();
            Mantiss.IssueData issue = new Mantiss.IssueData();
            issue.category = issueData.Category;
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.project = new Mantiss.ObjectRef();
            issue.project.id = project.ID;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
        /*
        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantiss.MantisConnectPortTypeClient client =
            new Mantiss.MantisConnectPortTypeClient();
            Mantiss.ProjectData[] projectsM =  client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> projects = new List<ProjectData>();

            foreach (Mantiss.ProjectData p in projectsM)
            {
                projects.Add(new ProjectData()
                {
                    Name = p.name,
                    ID = p.id
                });
            }
            return projects;
        }

    */

    }
}
