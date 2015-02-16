using System.Web.Mvc;
using Auth.Contracts;
using Auth.Data.Repository;
using Auth.Model;

namespace Auth.FormHandlers
{
    using Auth.ViewModel;
    public class UserCustomFormFormHandler :
        IFormHandler<UserCustomFormViewModel>
    {
        private UserFormRepository userFormRepository;

        public UserCustomFormFormHandler()
        {
            userFormRepository=new UserFormRepository();
        }
        public void Handle(UserCustomFormViewModel form)
        {
            var userForm = new UserForm();
            userForm.Id = form.FormId;
            userForm.FormValues = form.UserValues;
            userForm.Name = form.Name;
            userForm.User = new User {Id = form.User.Information.Id};
            userForm.UserId = form.User.Information.Id;

            userFormRepository.Set(userForm);
        }
    }
}