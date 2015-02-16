using System.Collections.Generic;

namespace Auth.Model
{
    public class UserRole : BaseModel
    {
        public virtual List<User> Users { get; set; }
        public string Name { get; set; }
    }
}