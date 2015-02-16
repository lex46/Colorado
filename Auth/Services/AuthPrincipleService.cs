using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Auth.Contracts;
using Auth.Security;

namespace Auth.Services
{
    public class AuthPrincipalService : IPrincipalService
    {
        private readonly HttpContextBase _context;

        public AuthPrincipalService(HttpContextBase context)
        {
            _context = context;
        }

        #region IPrincipalService Members

        public IPrincipal GetCurrent()
        {
            IPrincipal user = _context.User;
            if (user != null)
                return user;

            var authCookie = _context.Request.Cookies[FormsAuthentication.FormsCookieName]; ;
            if (authCookie == null)
                return new AuthPrincipal(new AuthIdentity((FormsAuthenticationTicket)null));
            
            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var identity = new AuthIdentity(ticket);
            var principal = new AuthPrincipal(identity);
            return principal;
        }

        #endregion
    }
}