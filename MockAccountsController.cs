using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace DecoratedWebApi.Mock
{
    public class MockAccountsController: DecoratedWebApi.AccountsController
    {
        public MockAccountsController(IDataProvider dataProvider)
            :base(dataProvider)
        { }

        [Route("api/QA/accounts/{accountNumber}")]
        public IHttpActionResult Get(string accountNumber)
        {
            if(accountNumber == "123456")
            {
                return NotFound();
            }

            return Ok(base.Get(accountNumber));
        }
    }
}