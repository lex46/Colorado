using System;
using System.Linq;
using Auth.Model;
using System.Data.Entity;
namespace Auth.Data.Repository
{
    public class UserRepository :
        BaseRepository<User>
    {
        public User Get(string name)
        {
            return Set
                .Include(x => x.Roles)
                .SingleOrDefault(x =>
                    string.Equals(x.Username,
                                  name));
        }
    }
}