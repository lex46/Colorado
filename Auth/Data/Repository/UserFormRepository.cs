using System;
using System.Linq;
using Auth.Model;
using System.Data.Entity;

namespace Auth.Data.Repository
{
    public class UserFormRepository
    {
        private readonly AuthContext context;
        public UserFormRepository()
        {
            context = new AuthContext();
        }
        public UserForm Get(string userName, string formName)
        {
            return 
            context.UserForms
                .SingleOrDefault(x =>
                    string.Equals(x.Name, formName) &&
                    string.Equals(x.User.Username, userName));
        }
        public void Set(UserForm form)
        {
            context.UserForms.Attach(form);
            context.Entry(form).State =
                form.Id == 0 ?
                                   EntityState.Added :
                                   EntityState.Modified; 
            context.SaveChanges();
        }
    }
}