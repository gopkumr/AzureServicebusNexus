using NexusExplorer.Domain.Models;

namespace NexusExplorer.Domain.Services.Abstractions
{
    public interface IServicebusDataService
    {
        ActionResponse<NexusNamespace?> Connect(string namespaceName, NexusAuthenticationOptions authenticationOptions);

        ActionResponse<IEnumerable<NexusMessage>> ReadMessages(string topic, string subscriptionName);

        ActionResponse<IEnumerable<NexusMessage>> ReadQueueMessages(string queueName);

        ActionResponse<IEnumerable<NexusMessage>> PeekMessages(string topic, string subscriptionName);

        ActionResponse<IEnumerable<NexusMessage>> PeekQueueMessages(string queueName);

        ActionResponse<string> SendMessageToTopic(string topic, NexusMessage message);

        ActionResponse<string> SendMessageToQueue(string queueName, NexusMessage message);

        ActionResponse<string> CompleteMessageFromTopic(string topic, NexusMessage message);

        ActionResponse<string> CompleteMessageFromQueue(string queueName, NexusMessage message);

        ActionResponse<string> ResendMessageToTopic(string topic, NexusMessage message);

        ActionResponse<string> ResendMessageToQueue(string queueName, NexusMessage message);

    }
}
