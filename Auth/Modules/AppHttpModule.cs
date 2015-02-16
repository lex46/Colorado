using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Auth.Contracts;
using Auth.Providers;
using Auth.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace Auth.Modules
{
    public class AppHttpModule : IHttpModule
    {
        private LoggingProvider logger;

        public AppHttpModule()
        {
            logger = new LoggingProvider();
        }
        static AppHttpModule()
        {
            Bootstrapper.Initialise();
            ConfigureLogger();
            RegisterRoutes(RouteTable.Routes);
        }
        public void Init(HttpApplication context)
        {
            context.Error += ContextOnError;
            context.BeginRequest += BeginRequest;
        }
        public void Dispose()
        {
        }
        private void BeginRequest(object sender, EventArgs eventArgs)
        {

        }
        private void ContextOnError(object sender, EventArgs eventArgs)
        {
            var app = sender as HttpApplication;
            app.Context.Response.Clear();
            var exception = app.Server.GetLastError();
            logger.Log(app.Context.Error.ToString());
            app.Server.ClearError();
            ReirectOnError(app.Context, exception);
        }

        private void ReirectOnError(HttpContext context, Exception exception)
        {
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "General";
                        break;
                }
                context.Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
            }
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = "" } // Parameter defaults
                );
            routes.MapRoute(
                "Form", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Form", name = "" } // Parameter defaults
                );
        }
        private static void ConfigureLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}