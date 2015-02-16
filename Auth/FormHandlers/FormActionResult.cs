namespace Auth.FormHandlers
{
    using System.Web.Mvc;

    public class FormActionResult<T> : ActionResult
    {
        public ViewResult Failure { get; private set; }
        public ActionResult Success { get; private set; }
        public T Form { get; private set; }
        private bool requiresValidation { get; set; }
        public FormActionResult(T form, ActionResult success, ViewResult failure, bool requiresValidation = true)
        {
            Form = form;
            Success = success;
            Failure = failure;
            requiresValidation = requiresValidation;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (requiresValidation && !context.Controller.ViewData.ModelState.IsValid)
            {
                Failure.ExecuteResult(context);

                return;
            }

            var handler = DependencyResolver.Current.GetService<IFormHandler<T>>();

            handler.Handle(Form);

            Success.ExecuteResult(context);
        }
    }
}