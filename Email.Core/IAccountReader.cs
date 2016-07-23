using System.Collections.Generic;

namespace Email.Core
{
    public interface IAccountReader
    {
        IList<Account> GetAccounts();
    }
}