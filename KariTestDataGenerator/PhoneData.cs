using System.Xml.Serialization;

namespace KariTestDataGenerator
{
    public class PhoneData
    {
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        public PhoneData()
        {
            PhoneNumber = "";
            Name = "";
            Email = "";
        }

        public PhoneData(string phoneNumber, string name, string email)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Email = email;
        }
    }
}