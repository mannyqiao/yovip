
namespace Enjoy.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Autofac;
    using Enjoy.Core;
    using Enjoy.WarmupStarter;
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Starter<IEnjoyHost> starter;
        protected void Application_Start()
        {
            starter = new Starter<IEnjoyHost>(Initialization, HostBeginRequest, HostEndRequest);
            starter.LaunchStartupThread(this);
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
        static IEnjoyHost Initialization(HttpApplication application)
        {
            var host = EnjoyStater.CreateHost(MvcSingletons);
            host.BeginRequest();
            host.EndRequest();
            return host;
        }
        protected void Application_BeginRequest()
        {
            starter.OnBeginRequest(this);
        }

        protected void Application_EndRequest()
        {
            starter.OnEndRequest(this);
        }

        static void HostBeginRequest(HttpApplication application, IEnjoyHost host)
        {
            application.Context.Items["originalHttpContext"] = application.Context;
            host.BeginRequest();
        }
        static void HostEndRequest(HttpApplication application, IEnjoyHost host)
        {
            host.EndRequest();
        }
        static void MvcSingletons(ContainerBuilder builder)
        {
            RegisterRoutes(RouteTable.Routes);      
            builder.Register(ctx => RouteTable.Routes).SingleInstance();
            builder.Register(ctx => System.Web.ModelBinding.ModelBinders.Binders).SingleInstance();
            builder.Register(ctx => ViewEngines.Engines).SingleInstance();
        }
    }
}
