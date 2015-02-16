using System.Data.Entity;
using Auth.Data.Conventions;
using Auth.Model;

namespace Auth.Data
{
    public class AuthContext : DbContext
    {
        public AuthContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserForm> UserForms { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
        }
    }
}