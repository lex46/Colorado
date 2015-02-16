using System.Security.Principal;

namespace Auth.Contracts
{
    public interface IPrincipalService
    {
        IPrincipal GetCurrent();
    }
}