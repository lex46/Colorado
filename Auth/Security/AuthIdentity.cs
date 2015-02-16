using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using Auth.Infra;
using Auth.Model;
using Newtonsoft.Json;

namespace Auth.Security
{
    public class AuthIdentity : IIdentity
    {
        public AuthIdentity(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                Name = Constants.GUEST_NAME;
                Roles = new List<string> { Constants.ROLE_GUEST};
                return;
            }

            var data = JsonConvert.DeserializeObject<AuthCookie>(ticket.UserData);

            if (data == null)
            {
                AsGuest();
                return;
            }

            Id = data.Id;
            Name = data.UserName;
            Email = data.Email;
            Roles = data.Roles ?? new List<string> { Constants.ROLE_USER };
            RememberMe = data.RememberMe;
        }

        public AuthIdentity(User user)
        {
            if (user == null)
            {
                AsGuest();
                return;
            }

            Id = user.Id;
            Email = user.Email;
            Name = user.Username;
            Roles = user.Roles.Select(x => x.Name).ToList();
        }

        private void AsGuest()
        {
            Name = Constants.GUEST_NAME;
            Roles = new List<string> { Constants.ROLE_GUEST };
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        public IList<string> Roles { get; set; }

        #region IIdentity Members
        public string AuthenticationType
        {
            get { return "AuthForms"; }
        }

        public bool IsAuthenticated
        {
            get { return !(Id == 0 || string.IsNullOrWhiteSpace(Email)); }
        }

        public string Name { get; protected set; }
        #endregion
    }
}