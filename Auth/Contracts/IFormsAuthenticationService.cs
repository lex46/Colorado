using Auth.Model;

namespace Auth.Contracts
{
    public interface IFormsAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
    }
}