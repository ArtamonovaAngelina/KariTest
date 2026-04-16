using NUnit.Framework;

namespace KariTests
{
    [TestFixture]
    public class KariAuthTest : TestBase
    {
        [Test]
        public void AuthorizationTest()
        {
            PhoneData phone = new PhoneData("9656255446");
            
            app.Navigation.OpenHomePage();
            app.Navigation.OpenLoginPage();
            app.Login.Login(phone);
            
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Тест авторизации пройден!");
        }
    }
}