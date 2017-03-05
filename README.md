# Problem 

It is often required to have mock behaviour of REST APIs so that API clients can test different scenarios. How to provide mock behaviour in a REST API without investing in writing lot of code?

# Solution

The solution here is based on decorator pattern. 

  1. Create a Mock controller that inherits from controller it intends to Mock. Attach a route with a prefix like "QA" using Route attribute.
 
 ```
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
```

2. Register the mock based on target environment in the configuration

```
            if(ConfigurationManager.AppSettings["Environment"] == "QA")
            {
                config.MapHttpAttributeRoutes();                
            }
```

The mock API route won't be registered in the Live environment. Client can switch to Mock behaviour in QA environment only if they want otherwise they can keep hitting the normal urls.
