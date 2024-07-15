using AzureServicebusNexus.Domain.Models;

namespace AzureServicebusNexus.ServiceBus.Abstractions
{
    public interface IServicebusDataService
    {
        ActionResponse<IEnumerable<NexusServicebusMessage>> ReadMessages(string topic, string subscriptionName);

        ActionResponse<IEnumerable<NexusServicebusMessage>> ReadQueueMessages(string queueName);

        ActionResponse<IEnumerable<NexusServicebusMessage>> PeekMessages(string topic, string subscriptionName);

        ActionResponse<IEnumerable<NexusServicebusMessage>> PeekQueueMessages(string queueName);

        ActionResponse<string> SendMessageToTopic(string topic, NexusServicebusMessage message);

        ActionResponse<string> SendMessageToQueue(string queueName, NexusServicebusMessage message);

        ActionResponse<string> CompleteMessageFromTopic(string topic, NexusServicebusMessage message);

        ActionResponse<string> CompleteMessageFromQueue(string queueName, NexusServicebusMessage message);

        ActionResponse<string> ResendMessageToTopic(string topic, NexusServicebusMessage message);

        ActionResponse<string> ResendMessageToQueue(string queueName, NexusServicebusMessage message);

    }
}
