using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Email.Core
{
    public class XmlAccountReader : IAccountReader
    {
        public IList<Account> GetAccounts()
        {
            using (var stream = File.OpenRead("accounts.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Account>), new XmlRootAttribute("accounts"));
                return (List<Account>) serializer.Deserialize(stream);
            }
        }
    }
}