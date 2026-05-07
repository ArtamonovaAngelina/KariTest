using NUnit.Framework;
using KariTests.Core;
using KariTests.Models;
using KariTests.Helpers;

namespace KariTests.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            app.Login.Logout();
            
            PhoneData validUser = new PhoneData("9656255446", "Тестовый", "test@mail.ru");
            
            app.Navigation.OpenLoginPage();
            app.Login.Login(validUser);
            
            bool isLoggedIn = app.Login.IsLoggedIn();
            Assert.That(isLoggedIn, Is.True, "Авторизация c валидными данными не выполнена");
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Login.Logout();
            
            PhoneData invalidUser = new PhoneData("0000000000", "Неверный", "fake@mail.ru");
            
            app.Navigation.OpenLoginPage();
            app.Login.SelectPhoneLogin();
            app.Login.EnterPhoneNumber(invalidUser);
            app.Login.SubmitPhoneNumber();
            
            bool isLoggedIn = app.Login.IsLoggedIn();
            Assert.That(isLoggedIn, Is.False, "Авторизация c невалидными данными не должна проходить");
        }
    }
}