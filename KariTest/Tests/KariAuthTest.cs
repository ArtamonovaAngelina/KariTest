using NUnit.Framework;
using KariTests.Core;
using KariTests.Models;
using KariTests.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace KariTests.Tests
{
    [TestFixture]
    public class KariAuthTest : TestBase
    {
        [Test]
        public void AuthorizationTestFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PhoneData>));
            List<PhoneData> phones;
            
            using (StreamReader reader = new StreamReader("testdata.xml"))
            {
                phones = (List<PhoneData>)serializer.Deserialize(reader);
            }
            
            Assert.That(phones.Count, Is.GreaterThan(0), "XML не содержит данных");
            Console.WriteLine($"Загружено {phones.Count} записей из XML");
            
            PhoneData phone = phones[0];
            Console.WriteLine($"Тестируем: {phone.Name} | {phone.PhoneNumber} | {phone.Email}");
            
            app.Navigation.OpenLoginPage();
            app.Login.Login(phone);
            
            bool isLoggedIn = app.Login.IsLoggedIn();
            Assert.That(isLoggedIn, Is.True, $"Авторизация не выполнена для {phone.PhoneNumber}");
            
            Console.WriteLine($"Тест авторизации пройден для {phone.Name}");
        }

        [Test]
        public void AuthorizationTest()
        {
            PhoneData phone = new PhoneData("9656255446", "Тест", "test@mail.ru");
            
            app.Navigation.OpenLoginPage();
            app.Login.Login(phone);
            
            bool isLoggedIn = app.Login.IsLoggedIn();
            Assert.That(isLoggedIn, Is.True, "Авторизация не выполнена");
            
            System.Console.WriteLine("Тест авторизации пройден!");
        }
    }
}