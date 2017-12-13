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
    public class LogInOutHelper : HelperBase
    {
        private string baseURL;

        public LogInOutHelper(ApplicationManager manager, String baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> refs = driver.FindElements(By.XPath("//table/tbody/tr/td/a"));
            foreach (IWebElement r in refs)
            {
                string name = r.Text;
                string href = r.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData(name, null) {
                    ID = id
                });
            }

            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php? user_id = " + account.ID;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click(); 
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return driver;
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn(account))
                {
                    return;
                }
                else
                {
                    Type(By.Name("username"), account.Name);
                    driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                    Type(By.Name("password"), account.Password);
                    driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUsername() == account.Name;
        }

        public string GetLoggedUsername()
        {
            if (IsLoggedIn() )
            {
                string text = driver.FindElement(By.ClassName("user-info")).Text;
                return text;
            }
            else
            {
                return "";
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("navbar"));
        }

        /*public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }*/
    }
}
