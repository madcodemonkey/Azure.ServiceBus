using Azure.Messaging.ServiceBus;

namespace ServiceBusMessageTransceiver;

public class SendDataService
{
    private readonly ServiceBusClient _client;
    private readonly string _queueName;
    private readonly DealFactory _dealFactory;

    public SendDataService(ServiceBusClient client, string queueName)
    {
        _client = client;
        _queueName = queueName;
        _dealFactory = new DealFactory();
    }

    public async Task WorkAsync(int numberOfMessagesToSend)
    {
        // Sending data
        await using var sender = _client.CreateSender(_queueName);

        // create a batch 
        using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

        for (int i = 1; i <= numberOfMessagesToSend; i++)
        {
            // try adding a message to the batch
            if (!messageBatch.TryAddMessage(new ServiceBusMessage(_dealFactory.CreateSerializedDeal())))
            {
                // if an exception occurs
                throw new Exception($"Exception {i} has occurred.");
            }
        }

        // Use the producer client to send the batch of messages to the Service Bus queue
        await sender.SendMessagesAsync(messageBatch);
        Console.WriteLine($"A batch of {numberOfMessagesToSend} messages has been published to the queue.");
    }
}