using NexusExplorer.Domain.Models;
using NexusExplorer.Domain.Services.Abstractions;
using Azure.Identity;
using Azure.Messaging.ServiceBus.Administration;
using System.Collections.Generic;

namespace NexusExplorer.AzureServiceBus.Implementations
{
    public class ServicebusAdminService : IServicebusAdminService
    {
        ServiceBusAdministrationClient? _serviceBusAdministrationClient;

        public NexusNamespace? NexusNamespace { get; set; }

        public async Task<ActionResponse<NexusNamespace?>> Connect(string namespaceName, NexusAuthenticationOptions authenticationOptions)
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
                TenantId = authenticationOptions.TenantId
            };

            var fullyQualifiedNamespaceName = namespaceName;
            if (!namespaceName.EndsWith(".servicebus.windows.net"))
               fullyQualifiedNamespaceName = $"{namespaceName}.servicebus.windows.net";

            _serviceBusAdministrationClient = new ServiceBusAdministrationClient(fullyQualifiedNamespaceName, new DefaultAzureCredential(options));

            if (_serviceBusAdministrationClient != null)
            {
                var servicebusProperties = await _serviceBusAdministrationClient.GetNamespacePropertiesAsync();
                this.NexusNamespace = new NexusNamespace
                {
                    Name = servicebusProperties.Value.Name
                };

                return new ActionResponse<NexusNamespace?>(this.NexusNamespace);
            }

            return new ActionResponse<NexusNamespace?>("Unable to connect to Azure Service Bus");
        }

        public ActionResponse<IEnumerable<NexusQueue>> GetQueues()
        {
            try
            {
                if (_serviceBusAdministrationClient == null)
                    return new ActionResponse<IEnumerable<NexusQueue>>("Empty service bus client, please connect to service bus before getting queues");

                var queues = _serviceBusAdministrationClient.GetQueuesAsync();
                var nexusQueues = new List<NexusQueue>();

                foreach (var queue in queues.ToBlockingEnumerable())
                {
                    nexusQueues.Add(new NexusQueue
                    {
                        Name = queue.Name,
                        IsEnabled = queue.Status == EntityStatus.Active,
                        LockDuration = queue.LockDuration,
                        MaxDeliveryCount = queue.MaxDeliveryCount,
                        SessionRequired = queue.RequiresSession
                    });
                }
                return new ActionResponse<IEnumerable<NexusQueue>>(nexusQueues);
            }
            catch (Exception ex)
            {
                return new ActionResponse<IEnumerable<NexusQueue>>(ex.Message);
            }
        }

        public ActionResponse<IEnumerable<NexusTopic>> GetTopics()
        {
            try
            {
                if (_serviceBusAdministrationClient == null)
                    return new ActionResponse<IEnumerable<NexusTopic>>("Empty service bus client, please connect to service bus before getting topics");

                var topics = _serviceBusAdministrationClient.GetTopicsAsync();
                var nexusTopics = new List<NexusTopic>();

                foreach (var topic in topics.ToBlockingEnumerable())
                {
                    nexusTopics.Add(new NexusTopic
                    {
                        Name = topic.Name,
                        IsEnabled = topic.Status == EntityStatus.Active,
                    });
                }
                return new ActionResponse<IEnumerable<NexusTopic>>(nexusTopics);
            }
            catch (Exception ex)
            {
                return new ActionResponse<IEnumerable<NexusTopic>>(ex.Message);
            }
        }

        public ActionResponse<IEnumerable<NexusTopicSubscription>> GetTopicSubscriptions(string topicName)
        {
            try
            {
                if (_serviceBusAdministrationClient == null)
                    return new ActionResponse<IEnumerable<NexusTopicSubscription>>("Empty service bus client, please connect to service bus before getting topics");

                var subsriptions = _serviceBusAdministrationClient.GetSubscriptionsAsync(topicName);
                var nexusSubsriptions = new List<NexusTopicSubscription>();

                foreach (var subscription in subsriptions.ToBlockingEnumerable())
                {
                    nexusSubsriptions.Add(new NexusTopicSubscription
                    {
                        Name = subscription.SubscriptionName,
                        IsEnabled = subscription.Status == EntityStatus.Active,
                        LockDuration = subscription.LockDuration,
                        MaxDeliveryCount = subscription.MaxDeliveryCount,
                        SessionRequired = subscription.RequiresSession
                    });
                }
                return new ActionResponse<IEnumerable<NexusTopicSubscription>>(nexusSubsriptions);
            }
            catch (Exception ex)
            {
                return new ActionResponse<IEnumerable<NexusTopicSubscription>>(ex.Message);
            }

        }
    }
}
