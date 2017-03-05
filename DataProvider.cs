using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratedWebApi
{
    public class DataProvider : IDataProvider
    {
        public AccountDetails GetAccount(string accNumber)
        {
            return new AccountDetails()
            {
                AccountNumber = accNumber,
                Name = "Name",
                IsActive = true
            };
        }
    }
}
