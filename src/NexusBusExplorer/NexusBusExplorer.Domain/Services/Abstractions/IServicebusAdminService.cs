using NexusBusExplorer.Domain.Models;

namespace NexusBusExplorer.Domain.Services.Abstractions
{
    public interface IServicebusAdminService
    {
        NexusBusNamespace Connect(string tenantId, string subscriptionId, string namespaceName);

        Task<IEnumerable<NexusBusTopic>> GetTopics();

        Task<IEnumerable<NexusBusQueue>> GetQueues();
    }
}
