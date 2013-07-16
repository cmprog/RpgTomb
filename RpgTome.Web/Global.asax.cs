using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using RpgTome.Model.Repositories;
using RpgTome.Providers;
using RpgTome.Settings;

namespace RpgTome.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
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
            lBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            var lContainer = lBuilder.Build();

            
            var lResolver = new AutofacDependencyResolver(lContainer);
            DependencyResolver.SetResolver(lResolver);
        }
    }
}