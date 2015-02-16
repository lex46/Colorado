using System;
using System.Web;

namespace Auth.Services
{
    public class CookiesService
    {
        private HttpCookieCollection Cookies
        {
            get { return HttpContext.Current.Response.Cookies; }
        }
        public void Set(string name, string value, DateTime expirationDate)
        {
            var coockie = new HttpCookie(name)
            {
                Expires = expirationDate ,
                Value = value
            };
            HttpContext.Current.Response.Cookies.Add(coockie);
        }
        public string Get(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
                return null;

            if (string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[name].Value))
                return null;

            return HttpContext.Current.Request.Cookies[name].Value;
        }
        public void Delete(string name)
        {
            var httpCookie = HttpContext.Current.Response.Cookies[name];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }
    }
}