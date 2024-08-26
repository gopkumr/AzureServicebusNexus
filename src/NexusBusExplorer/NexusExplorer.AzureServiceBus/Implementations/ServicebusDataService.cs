using NexusExplorer.Domain.Models;
using NexusExplorer.Domain.Services.Abstractions;

namespace NexusExplorer.AzureServiceBus.Implementations
{
    public class ServicebusDataService : IServicebusDataService
    {
        public ActionResponse<string> CompleteMessageFromQueue(string queueName, NexusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> CompleteMessageFromTopic(string topic, NexusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<NexusNamespace?> Connect(string namespaceName, NexusAuthenticationOptions authenticationOptions)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusMessage>> PeekMessages(string topic, string subscriptionName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusMessage>> PeekQueueMessages(string queueName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusMessage>> ReadMessages(string topic, string subscriptionName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusMessage>> ReadQueueMessages(string queueName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> ResendMessageToQueue(string queueName, NexusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> ResendMessageToTopic(string topic, NexusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> SendMessageToQueue(string queueName, NexusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> SendMessageToTopic(string topic, NexusMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
