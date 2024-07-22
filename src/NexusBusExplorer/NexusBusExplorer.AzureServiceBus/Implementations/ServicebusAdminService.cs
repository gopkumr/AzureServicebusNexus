using Azure.ResourceManager.Resources;
using Azure.ResourceManager;
using NexusBusExplorer.Domain.Models;
using NexusBusExplorer.Domain.Services.Abstractions;
using Azure.Identity;
using Azure.ResourceManager.ServiceBus;

namespace NexusBusExplorer.AzureServiceBus.Implementations
{
    public class ServicebusAdminService : IServicebusAdminService
    {
        ArmClient? armClient;
        SubscriptionResource? subscription;
        ServiceBusNamespaceResource? serviecbusNamespace;

        public NexusBusNamespace Connect(string tenantId, string subscriptionId, string namespaceName)
        {
            var options = new DefaultAzureCredentialOptions
            {
                ExcludeAzureCliCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeAzurePowerShellCredential = true,
                ExcludeEnvironmentCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeVisualStudioCredential = true,
                ExcludeVisualStudioCodeCredential = true,
                ExcludeWorkloadIdentityCredential = true,
                ExcludeInteractiveBrowserCredential = false,
                TenantId= tenantId
            };

            armClient = new ArmClient(new DefaultAzureCredential(options));
            subscription = armClient.GetSubscriptionResource(new Azure.Core.ResourceIdentifier($"/subscriptions/{subscriptionId}"));

            var namespaceCollection = subscription.GetServiceBusNamespaces();
            serviecbusNamespace = namespaceCollection.FirstOrDefault(q=>q.Id.Name.Contains(namespaceName));

            if (serviecbusNamespace != null)
            {
                return new NexusBusNamespace
                {
                    Name = serviecbusNamespace.Id.Name
                };
            }

            return null;
        }

        public Task<IEnumerable<NexusBusQueue>> GetQueues()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NexusBusTopic>> GetTopics()
        {
            throw new NotImplementedException();
        }
    }
}
