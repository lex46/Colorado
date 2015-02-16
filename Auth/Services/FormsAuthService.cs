using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Auth.Contracts;
using Auth.Model;
using Auth.Security;
using Newtonsoft.Json;

namespace Auth.Services
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        private readonly HttpContextBase _httpContext;

        public FormsAuthenticationService(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        #region IFormsAuthenticationService Members

        public void SignIn(User user, bool createPersistentCookie)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var cookie = new AuthCookie
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.Username,
                RememberMe = createPersistentCookie,
                Roles = user.Roles.Select(x => x.Name).ToList()
            };

            string userData = JsonConvert.SerializeObject(cookie);
            var ticket = new FormsAuthenticationTicket(1, cookie.Email, DateTime.Now,
                                                       DateTime.Now.Add(FormsAuthentication.Timeout),
                                                       createPersistentCookie, userData);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { Expires = DateTime.Now.Add(FormsAuthentication.Timeout) };

            _httpContext.Response.Cookies.Add(httpCookie);
        }

        public void SignOut()
        {
            // Not worth covering, has been tested by Microsoft
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}