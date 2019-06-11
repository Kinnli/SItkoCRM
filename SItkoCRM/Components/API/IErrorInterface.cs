namespace SitkoCRM.Components.API
{
    public interface IErrorInterface
    {
        string Message { get; }
    }

    public class ErrorMessage : IErrorInterface
    {
        public ErrorMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
