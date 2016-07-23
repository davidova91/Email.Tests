using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Email.Core
{
    public class CsvAccountReader : IAccountReader
    {
        public IList<Account> GetAccounts()
        {
            return File.ReadLines("accounts.csv").Select(l =>
                new Account
                {
                    Email = l.Remove(l.IndexOf(',')),
                    Password = l.Substring(l.IndexOf(',') + 1)
                }).ToList();
        }
    }
}