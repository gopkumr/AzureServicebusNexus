using NexusBusExplorer.Domain.Models;

namespace NexusBusExplorer.ServiceBus.Abstractions
{
    public interface IServicebusDataService
    {
        ActionResponse<IEnumerable<NexusBusMessage>> ReadMessages(string topic, string subscriptionName);

        ActionResponse<IEnumerable<NexusBusMessage>> ReadQueueMessages(string queueName);

        ActionResponse<IEnumerable<NexusBusMessage>> PeekMessages(string topic, string subscriptionName);

        ActionResponse<IEnumerable<NexusBusMessage>> PeekQueueMessages(string queueName);

        ActionResponse<string> SendMessageToTopic(string topic, NexusBusMessage message);

        ActionResponse<string> SendMessageToQueue(string queueName, NexusBusMessage message);

        ActionResponse<string> CompleteMessageFromTopic(string topic, NexusBusMessage message);

        ActionResponse<string> CompleteMessageFromQueue(string queueName, NexusBusMessage message);

        ActionResponse<string> ResendMessageToTopic(string topic, NexusBusMessage message);

        ActionResponse<string> ResendMessageToQueue(string queueName, NexusBusMessage message);

    }
}
