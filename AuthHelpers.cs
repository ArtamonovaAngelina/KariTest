using OpenQA.Selenium;

namespace KariTests
{
    public class AuthHelpers : TestBase
    {
        public void OpenSite()
        {
            driver!.Navigate().GoToUrl("https://kari.com/");
            Wait(2000);
        }

        public void ClickUserIcon()
        {
            driver!.FindElement(By.CssSelector(".user")).Click();
            Wait(1000);
        }

        public void ClickLoginButton()
        {
            driver!.FindElement(By.LinkText("Войти или зарегистрироваться")).Click();
            Wait(1000);
        }

        public void SelectPhoneLogin()
        {
            driver!.FindElement(By.CssSelector(".MuiButtonBase-root:nth-child(2) > .css-12pog11")).Click();
            Wait(500);
        }

        public void EnterPhoneNumber(PhoneData phone)
        {
            driver!.FindElement(By.Name("phone")).SendKeys(phone.PhoneNumber);
            Wait(500);
        }

        public void SubmitPhoneNumber()
        {
            var submitBtn = driver!.FindElement(By.CssSelector(".css-10vxmgq"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            Wait(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitBtn);
        }

        public void Login(PhoneData phone)
        {
            OpenSite();
            ClickUserIcon();
            ClickLoginButton();
            SelectPhoneLogin();
            EnterPhoneNumber(phone);
            SubmitPhoneNumber();
        }
    }
}