using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using KariTests.Helpers;

namespace KariTests.Core
{
    public class AppManager
    {
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();
        
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        
        private NavigationHelper navigation;
        private LoginHelper login;

        private AppManager()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            baseURL = "https://kari.com/";
            verificationErrors = new StringBuilder();

            navigation = new NavigationHelper(this, baseURL);
            login = new LoginHelper(this);
        }

        ~AppManager()
        {
            try
            {
                driver?.Quit();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        public static AppManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public NavigationHelper Navigation
        {
            get { return navigation; }
        }

        public LoginHelper Login
        {
            get { return login; }
        }
    }
}