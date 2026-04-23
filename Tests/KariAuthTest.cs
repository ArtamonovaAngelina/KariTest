using NUnit.Framework;
using KariTests.Core;
using KariTests.Models;
using KariTests.Helpers;

namespace KariTests.Tests
{
    [TestFixture]
    public class KariAuthTest : TestBase
    {
        [Test]
        public void AuthorizationTest()
        {
            PhoneData phone = new PhoneData("9656255446");
            
            app.Navigation.OpenLoginPage();
            app.Login.Login(phone);
            
            bool isLoggedIn = app.Login.IsLoggedIn();
            Assert.That(isLoggedIn, Is.True, "Авторизация не выполнена");
            
            System.Threading.Thread.Sleep(2000);
            System.Console.WriteLine("✅ Тест авторизации пройден!");
        }
    }
}