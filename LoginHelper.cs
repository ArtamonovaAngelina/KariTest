using OpenQA.Selenium;

namespace KariTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager) { }

        public void SelectPhoneLogin()
        {
            // Выбор входа по телефону
            try
            {
                driver.FindElement(By.CssSelector(".MuiButtonBase-root:nth-child(2) > .css-12pog11")).Click();
            }
            catch
            {
                driver.FindElement(By.XPath("//button[contains(text(), 'Телефон')]")).Click();
            }
            Wait(500);
        }

        public void EnterPhoneNumber(PhoneData phone)
        {
            var phoneField = driver.FindElement(By.Name("phone"));
            phoneField.Clear();
            phoneField.SendKeys(phone.PhoneNumber);
            Wait(500);
        }

        public void SubmitPhoneNumber()
        {
            // Кнопка "Войти" с классом css-1tflwbt
            var submitBtn = driver.FindElement(By.CssSelector(".css-1tflwbt"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            Wait(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitBtn);
        }

        public void Login(PhoneData phone)
        {
            SelectPhoneLogin();
            EnterPhoneNumber(phone);
            SubmitPhoneNumber();
        }
    }
}