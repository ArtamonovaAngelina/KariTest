namespace KariTests.Models
{
    public class PhoneData
    {
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

        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}