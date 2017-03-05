using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DecoratedWebApi
{
    public class AccountsController: ApiController
    {
        private IDataProvider _dataProvider;

        public AccountsController(IDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        // GET api/values 
        public AccountDetails Get(string accountNumber)
        {
            return this._dataProvider.GetAccount(accountNumber);
        }


    }
}