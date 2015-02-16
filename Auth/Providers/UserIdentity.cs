using System;
using System.Security.Principal;

using Auth.Data.Repository;
using Auth.Model;

namespace Auth.Providers
{
    public class UserIndentity : IIdentity
    {
        public virtual User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                return (User == null) ?
                    null : User.Username;
            }
        }

        public void Init(string userName, UserRepository repository)
        {
            if (!string.IsNullOrEmpty(userName))
                User = repository.Get(userName);
        }

        public void Init(string userName)
        {
            if (!String.IsNullOrEmpty(userName))
                User = new User
                {
                    Username = userName
                };
        }
    }
}