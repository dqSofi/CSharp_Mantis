using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantiss_Tests
{
    public class LogInOutHelper : HelperBase
    {
        public LogInOutHelper(ApplicationManager manager)
            : base(manager)
        {
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
