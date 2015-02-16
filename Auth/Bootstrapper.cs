using System.Web;
using System.Web.Mvc;
using Auth.Contracts;
using Auth.FormHandlers;
using Auth.Services;
using Auth.ViewModel;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace Auth
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IPrincipalService, AuthPrincipalService>();
            container.RegisterType<IFormsAuthenticationService, FormsAuthenticationService>();
            container.RegisterType<HttpContextBase>(new InjectionFactory(c =>
            {
                return new HttpContextWrapper(HttpContext.Current);
            }));

            container.RegisterType<IFormHandler<UserCustomFormViewModel>, UserCustomFormFormHandler>();
        }
    }
}