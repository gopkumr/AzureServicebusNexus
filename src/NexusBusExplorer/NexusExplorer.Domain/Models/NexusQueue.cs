namespace NexusExplorer.Domain.Models
{
    public class NexusQueue
    {
        public string Name { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
        public bool SessionRequired { get; set; }
        public TimeSpan LockDuration { get; set; }
        public int MaxDeliveryCount { get; set; }
    }
}
