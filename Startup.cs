using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using System.Web.Http.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Owin;
using System.Configuration;

namespace DecoratedWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "AccountsApi",
                routeTemplate: "api/{controller}/{accountNumber}",
                defaults: new { id = RouteParameter.Optional }
            );

            if(ConfigurationManager.AppSettings["Environment"] == "QA")
            {
                config.MapHttpAttributeRoutes();                
            }

            appBuilder.UseWebApi(config);

            var builder = new ContainerBuilder();
            builder.RegisterType<DataProvider>().As<IDataProvider>();
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);            
        }
    }
}
