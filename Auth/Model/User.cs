using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auth.Model
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public IList<UserRole> Roles { get; set; }

        public User()
        {
            Roles=new List<UserRole>();
        }
    }
}