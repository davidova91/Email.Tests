using System.Xml.Serialization;

namespace Email.Core
{
    [XmlType("account")]
    public class Account
    {
        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        public string Name => Email.Remove(Email.IndexOf('@'));
    }
}