using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace Email.Core
{
    public class SqlAccountManager : IAccountReader
    {
        public IList<Account> GetAccounts()
        {
            using (var db = new LiteDatabase("accounts.db"))
            {
                var col = db.GetCollection<Account>("accounts");
                return col.FindAll().ToList();
            }
        }

        public void ResetDatabase(IList<Account> accounts)
        {
            using (var db = new LiteDatabase("accounts.db"))
            {
                var col = db.GetCollection<Account>("accounts");
                col.Drop();
                col.InsertBulk(accounts);
            }
        }
    }
}