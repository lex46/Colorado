using System;
using System.Linq;
using System.Security.Principal;

namespace Auth.Security
{
    public class AuthPrincipal : IPrincipal
    {
        private readonly AuthIdentity _identity;

        public AuthPrincipal(AuthIdentity identity)
        {
            _identity = identity;
        }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            return
                _identity.Roles.Any(
                    current => string.Compare(current, role, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public AuthIdentity Information
        {
            get { return _identity; }
        }

        public bool IsUser
        {
            get { return !IsGuest; }
        }

        public bool IsGuest
        {
            get { return IsInRole("guest"); }
        }

        #endregion
    }
}