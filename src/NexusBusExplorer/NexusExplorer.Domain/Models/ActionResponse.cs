namespace NexusExplorer.Domain.Models
{
    public class ActionResponse<T>
    {
        public ActionResponse()
        {
            
        }

        public ActionResponse(T content)
        {
            Content = content;
            Success = true;
        }

        public ActionResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = false;
        }

        public T Content { get; set; } = default!;

        public bool Success { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}
