using AzureServicebusNexus.Domain.Models;
using AzureServicebusNexus.ServiceBus.Abstractions;

namespace AzureServicebusNexus.ServiceBus.Implementations
{
    public class ServicebusDataService : IServicebusDataService
    {
        public ActionResponse<string> CompleteMessageFromQueue(string queueName, NexusServicebusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> CompleteMessageFromTopic(string topic, NexusServicebusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusServicebusMessage>> PeekMessages(string topic, string subscriptionName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusServicebusMessage>> PeekQueueMessages(string queueName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusServicebusMessage>> ReadMessages(string topic, string subscriptionName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusServicebusMessage>> ReadQueueMessages(string queueName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> ResendMessageToQueue(string queueName, NexusServicebusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> ResendMessageToTopic(string topic, NexusServicebusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> SendMessageToQueue(string queueName, NexusServicebusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> SendMessageToTopic(string topic, NexusServicebusMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
