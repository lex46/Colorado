namespace Auth.FormHandlers
{
    public interface IFormHandler<T>
    {
        void Handle(T form);
    }
}