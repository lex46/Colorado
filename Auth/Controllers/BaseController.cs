using System.Web.Routing;

namespace Auth.Controllers
{
    using System.Web.Mvc;
    using FormHandlers;
    using Providers;
    public class BaseController : Controller
    {
        protected LoggingProvider Logger;
        public BaseController()
        {
            Logger = new LoggingProvider();
        }

        protected FormActionResult<TForm> HandleForm<TForm>(
            TForm form,
            ActionResult success,
            bool requiresValidation = true)
        {
            var failure = View(form);

            return new FormActionResult<TForm>(form, success, failure, requiresValidation);
        }
    }
}