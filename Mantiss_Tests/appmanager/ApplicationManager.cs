using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantiss_Tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FTPHelper FTP { get; private set; }
        public LogInOutHelper Auth { get; private set; }
        public ProjectHelper Project { get; private set; }

        //устанавливает соответствие между текущим потоком и объектом типа апп менеджер
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            FTP = new FTPHelper(this);
            Auth = new LogInOutHelper(this);
            Project = new ProjectHelper(this);
        }

        //деструктор, всегда начинается с ~
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            //если для текущего потока внутри хранилища ничего не создано, то создать
            if (! app.IsValueCreated) 
            {
                ApplicationManager NewInstance = new ApplicationManager();
                NewInstance.driver.Url = "http://localhost/mantisbt-2.8.0/login_page.php";
                app.Value = NewInstance;
                                
            }
            return app.Value;
        }


        
    }
}
