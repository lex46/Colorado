using System.Security.Principal;
using System.Web.Mvc;
using Auth.Contracts;
using Auth.Security;

namespace Auth.ViewModel
{
    public class BaseViewModel
    {
        public AuthPrincipal User
        {
            get
            {
                return
                    DependencyResolver
                        .Current.GetService<IPrincipalService>()
                        .GetCurrent() as AuthPrincipal;
            }
        }
    }
}