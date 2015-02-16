using System.Web.Mvc;

namespace Auth.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult HttpError404(string message)
        {
            return View("PageNotFound", message);
        }

        public ActionResult HttpError500(string message)
        {
            return View("ServerError", message);
        }
    }
}