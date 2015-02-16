using System.Linq;
using Auth.Infra;
using Auth.Model;

namespace Auth.Migrations
{
    using Data;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthContext context)
        {
            AddRoles(context);
            AddUsers(context);
        }

        private void AddRoles(AuthContext context)
        {
            if (null == context.UserRoles.SingleOrDefault(x => x.Name == Constants.ROLE_USER))
                context.UserRoles.Add(new UserRole()
                {
                    Name = Constants.ROLE_USER
                });
            if (null == context.UserRoles.SingleOrDefault(x => x.Name == Constants.ROLE_ADMIN))
                context.UserRoles.Add(new UserRole()
                {
                    Name = Constants.ROLE_ADMIN
                });
        }

        private void AddUsers(AuthContext context)
        {
            var userRole = context.UserRoles.SingleOrDefault(x => x.Name == Constants.ROLE_USER);
            var adminRole = context.UserRoles.SingleOrDefault(x => x.Name == Constants.ROLE_ADMIN);
            if (null == context.Users.SingleOrDefault(x => x.Username == "lex"))
                context.Users.Add(new User()
                {
                    Username = "lex",
                    Email = "boolex01@gmail.com",
                    Password = "test",
                    Roles = new[] { userRole }
                });
            if (null == context.Users.SingleOrDefault(x => x.Username == "user"))
                context.Users.Add(new User()
                {
                    Username = "user",
                    Email = "boolex01@gmail.com",
                    Password = "test",
                    Roles = new[] { userRole }
                });
            if (null == context.Users.SingleOrDefault(x => x.Username == "sa"))
                context.Users.Add(new User()
                {
                    Username = "sa",
                    Email = "boolex01@gmail.com",
                    Password = "1",
                    Roles = new[] { adminRole, userRole }
                });
        }


    }
}
