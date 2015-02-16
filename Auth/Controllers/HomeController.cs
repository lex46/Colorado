using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auth.Attributes;
using Auth.Contracts;
using Auth.Data.Repository;
using Auth.Model;
using Auth.Providers;
using Auth.Services;
using Auth.ViewModel;

namespace Auth.Controllers
{
    public class HomeController : BaseController
    {
        private UserFormRepository userFormRepository;
        protected IFormsAuthenticationService Forms;
        public HomeController(IFormsAuthenticationService forms)
        {
            Forms = forms;
            userFormRepository = new UserFormRepository();
        }
        public ActionResult UserForm(string id)
        {
            var formService = new UserCustomFormService();
            var forms = formService.All();

            var form =
                forms.SingleOrDefault(x => string.Equals(x.Key, id, StringComparison.InvariantCultureIgnoreCase));
            var viewModel = new UserCustomFormViewModel();
            
            viewModel.Template = form.Value;
            viewModel.Name = form.Key;
            if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
            {
                var userForm = userFormRepository.Get(HttpContext.User.Identity.Name, id);
                if (userForm != null)
                {
                    viewModel.FormId = userForm.Id;
                    viewModel.UserValues = userForm.FormValues;
                }
            }
            return View("userform", viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UserForm(UserCustomFormViewModel form)
        {
            var successResult =
               RedirectToAction("Index");

            return HandleForm(form, successResult, false);
        }

        public ActionResult Index()
        {

            var viewModel = new UserLoginViewModel();
            return View("Index", viewModel);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "login")]
        public ActionResult Login(UserLoginViewModel model)
        {
            var repository = new UserRepository();
            var user = repository.Get(model.Username);
            if (user != null && user.Password == model.Password)
            {
                Forms.SignIn(user, false);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "logout")]
        public ActionResult Logout(UserLoginViewModel model)
        {
            Forms.SignOut();
            return RedirectToAction("Index");
        }
    }
}