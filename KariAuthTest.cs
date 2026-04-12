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
            AuthHelpers auth = new AuthHelpers();
            auth.Login(phone);
            Wait(2000);
        }
    }
}