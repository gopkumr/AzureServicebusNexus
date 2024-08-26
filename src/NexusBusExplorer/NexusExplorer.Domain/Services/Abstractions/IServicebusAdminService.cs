using NexusExplorer.Domain.Models;

namespace NexusExplorer.Domain.Services.Abstractions
{
    public interface IServicebusAdminService
    {
        NexusNamespace? NexusNamespace { get; }

        Task<ActionResponse<NexusNamespace?>> Connect(string namespaceName, NexusAuthenticationOptions authenticationOptions);
        ActionResponse<IEnumerable<NexusTopic>> GetTopics();
        ActionResponse<IEnumerable<NexusQueue>> GetQueues();
        ActionResponse<IEnumerable<NexusTopicSubscription>> GetTopicSubscriptions(string topicName);
    }
}
