using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace KariTestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Использование: KariTestDataGenerator.exe <тип> <количество> <имя_файла> <формат>");
                Console.WriteLine("Типы: phone, user");
                Console.WriteLine("Форматы: xml, json");
                return;
            }

            string dataType = args[0];
            int count = int.Parse(args[1]);
            string fileName = args[2];
            string format = args[3];

            if (dataType == "phone")
            {
                GeneratePhoneData(count, fileName, format);
            }
            else if (dataType == "user")
            {
                GenerateUserData(count, fileName, format);
            }
            else
            {
                Console.WriteLine($"Неизвестный тип данных: {dataType}");
            }
        }

        static void GeneratePhoneData(int count, string fileName, string format)
        {
            List<PhoneData> phones = new List<PhoneData>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                string phoneNumber = GeneratePhoneNumber(rnd);
                string name = GenerateName(rnd);
                string email = GenerateEmail(name, rnd);

                phones.Add(new PhoneData(phoneNumber, name, email));
            }

            if (format.ToLower() == "xml")
            {
                SaveToXml(phones, fileName);
            }
            else if (format.ToLower() == "json")
            {
                SaveToJson(phones, fileName);
            }

            Console.WriteLine($"Сгенерировано {count} записей в файл {fileName}");
        }

        static void GenerateUserData(int count, string fileName, string format)
        {
            Console.WriteLine("Генерация пользователей...");
            GeneratePhoneData(count, fileName, format);
        }

        static string GeneratePhoneNumber(Random rnd)
        {
            return $"965{rnd.Next(1000000, 9999999)}";
        }

        static string GenerateName(Random rnd)
        {
            string[] firstNames = { "Анна", "Мария", "Екатерина", "Ольга", "Татьяна", 
                                     "Наталья", "Ирина", "Светлана", "Юлия", "Елена" };
            string[] lastNames = { "Иванова", "Петрова", "Сидорова", "Кузнецова", 
                                    "Смирнова", "Васильева", "Попова", "Соколова" };
            
            return $"{firstNames[rnd.Next(firstNames.Length)]} {lastNames[rnd.Next(lastNames.Length)]}";
        }

        static string GenerateEmail(string name, Random rnd)
        {
            string[] domains = { "mail.ru", "gmail.com", "yandex.ru", "inbox.ru" };
            string latinName = name.Replace(" ", ".").ToLower();
            return $"{latinName}{rnd.Next(100, 999)}@{domains[rnd.Next(domains.Length)]}";
        }

        static void SaveToXml<T>(T data, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, data);
            }
        }

        static void SaveToJson<T>(T data, string fileName)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}