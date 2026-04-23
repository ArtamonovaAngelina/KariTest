using OpenQA.Selenium;
using System.Text;
using KariTests.Core;

namespace KariTests.Helpers
{
    public class HelperBase
    {
        protected AppManager manager;
        protected IWebDriver driver;
        protected bool acceptNextAlert = true;
        protected StringBuilder verificationErrors;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
            this.verificationErrors = new StringBuilder();
        }

        protected void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        protected string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}