namespace Email.Core
{
    public class AccountReaderFactory
    {
        public IAccountReader Make(string name)
        {
            switch (name)
            {
                case "csv":
                    return new CsvAccountReader();
                case "xml":
                    return new XmlAccountReader();
                default:
                    return new SqlAccountManager();
            }
        } 
    }
}