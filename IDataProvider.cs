using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratedWebApi
{
    public interface IDataProvider
    {
        AccountDetails GetAccount(string accNumber);
    }
}
