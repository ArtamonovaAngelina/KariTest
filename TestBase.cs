using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace KariTests
{
    public class TestBase
    {
        protected static IWebDriver? driver;

        [SetUp]
        public void SetUp()
        {
            if (driver == null)
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver = null;
        }

        protected void Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}