using System.Security.Principal;
using Auth.Data.Repository;

namespace Auth.Providers
{
    public class UserPrincipal : IPrincipal
    {
        private readonly UserRepository repository;
        private UserIndentity userIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return userIdentity; }
        }

        public bool IsInRole(string role)
        {
            //if (userIdentity.User == null)
            //{
            //    return false;
            //}
            //return userIdentity.User.InRoles(role);
            return false;
        }

        #endregion


        public UserPrincipal(string name)
        {
            userIdentity=new UserIndentity();
            userIdentity.Init(name);
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}