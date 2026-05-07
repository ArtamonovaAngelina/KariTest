using NUnit.Framework;
using KariTests.Core;
using KariTests.Models;
using KariTests.Helpers;

namespace KariTests.Tests
{
    public class AuthBase : TestBase
    {
        protected PhoneData defaultUser;

        [SetUp]
        public void SetupAuth()
        {
            defaultUser = new PhoneData("9656255446", "Тестовый пользователь", "test@mail.ru");
            app.Login.Login(defaultUser);
        }
    }
}