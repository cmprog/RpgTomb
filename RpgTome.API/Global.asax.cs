using System.Reflection;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using RpgTome.API.App_Start;
using RpgTome.Model.Repositories;
using RpgTome.Providers;
using RpgTome.Settings;

namespace RpgTome.API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var lBuilder = new ContainerBuilder();
            lBuilder.RegisterModule(new SettingsModule(HostingEnvironment.MapPath("~/My.config")));
            lBuilder.RegisterModule(new RepositoriesModule());
            lBuilder.RegisterModule(new InternalProviderRegistrationModule());
            lBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var lContainer = lBuilder.Build();

            var lResolver = new AutofacWebApiDependencyResolver(lContainer);
            GlobalConfiguration.Configuration.DependencyResolver = lResolver;
        }
    }
}