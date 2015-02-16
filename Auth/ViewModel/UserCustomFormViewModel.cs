namespace Auth.ViewModel
{
    public class UserCustomFormViewModel : BaseViewModel
    {
        public long FormId { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string[] UserValues{ get; set; }
    }
}