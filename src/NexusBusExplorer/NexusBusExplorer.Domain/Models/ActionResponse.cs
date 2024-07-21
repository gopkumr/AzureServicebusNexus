namespace NexusBusExplorer.Domain.Models
{
    public class ActionResponse<T>
    {
        public T Content { get; set; } = default!;

        public bool Success { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}
