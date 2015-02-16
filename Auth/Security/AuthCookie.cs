using System.Collections.Generic;

namespace Auth.Security
{
    public class AuthCookie
    {
        public AuthCookie()
        {
            Roles = new List<string>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public bool RememberMe { get; set; }
    }
}