using OpenQA.Selenium;

namespace KariTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Wait(3000);
        }

        public void OpenLoginPage()
        {
            // Иконка пользователя (обнови, если нужно)
            try
            {
                driver.FindElement(By.CssSelector(".user")).Click();
            }
            catch
            {
                driver.FindElement(By.CssSelector("[class*='user']")).Click();
            }
            Wait(1000);
            
            // Кнопка "Войти или зарегистрироваться"
            driver.FindElement(By.LinkText("Войти или зарегистрироваться")).Click();
            Wait(1000);
        }
    }
}