using System.Security.Principal;

namespace Auth.Contracts
{
    public interface IAuthentication
    {
        void Login(string login);
        void LogOut();
        IPrincipal CurrentUser { get; }
    }
}