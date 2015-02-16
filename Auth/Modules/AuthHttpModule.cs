using System;
using System.Web;
using System.Web.Mvc;
using Auth.Contracts;
using Auth.Providers;

namespace Auth.Modules
{
    public class AuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Authenticate);
        }

        private void Authenticate(Object source, EventArgs e)
        {
            //var app = (HttpApplication)source;
            //var context = app.Context;

            //var auth = new AuthenticationProvider();
            //context.User = auth.CurrentUser;
            var principalService = DependencyResolver.Current.GetService<IPrincipalService>();
            var context = DependencyResolver.Current.GetService<HttpContextBase>();
            context.User = principalService.GetCurrent();
        }

        public void Dispose()
        {
        }
    }
}