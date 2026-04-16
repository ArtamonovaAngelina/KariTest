using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace KariTests
{
    public class AppManager
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper login;

        public AppManager()
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

        public void Stop()
        {
            driver.Quit();
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