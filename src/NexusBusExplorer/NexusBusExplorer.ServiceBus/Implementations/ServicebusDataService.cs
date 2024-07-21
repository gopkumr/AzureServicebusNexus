using NexusBusExplorer.Domain.Models;
using NexusBusExplorer.ServiceBus.Abstractions;

namespace NexusBusExplorer.ServiceBus.Implementations
{
    public class ServicebusDataService : IServicebusDataService
    {
        public ActionResponse<string> CompleteMessageFromQueue(string queueName, NexusBusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> CompleteMessageFromTopic(string topic, NexusBusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusBusMessage>> PeekMessages(string topic, string subscriptionName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusBusMessage>> PeekQueueMessages(string queueName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusBusMessage>> ReadMessages(string topic, string subscriptionName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<IEnumerable<NexusBusMessage>> ReadQueueMessages(string queueName)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> ResendMessageToQueue(string queueName, NexusBusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> ResendMessageToTopic(string topic, NexusBusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> SendMessageToQueue(string queueName, NexusBusMessage message)
        {
            throw new NotImplementedException();
        }

        public ActionResponse<string> SendMessageToTopic(string topic, NexusBusMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
