

namespace Enjoy.Portal.Dashboard
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using Enjoy.Core;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            EnjoyStater.Start(MvcSingletons);
        }
        protected void MvcSingletons(ContainerBuilder builder)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            builder.RegisterInstance(this)
                .As<MvcApplication>()
                .As<System.Web.HttpApplication>();
        }
    }
}
