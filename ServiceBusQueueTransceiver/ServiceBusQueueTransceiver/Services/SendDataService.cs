using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
 

namespace ServiceBusMessageTransceiver;

public class SendDataService : ISendDataService
{
    private readonly ServerBusSettings _settings;
    private readonly DealFactory _dealFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    public SendDataService(IOptions<ServerBusSettings> settings)
    {
        _settings = settings.Value;
        _dealFactory = new DealFactory();
    }
 

    public async Task WorkAsync(int numberOfMessagesToSend)
    {
        await using var client = new ServiceBusClient(_settings.ConnectionString);

            // Sending data
            await using var sender = client.CreateSender(_settings.QueueName);

        // create a batch 
        using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

        for (int order = 1; order <= numberOfMessagesToSend; order++)
        {
            // try adding a message to the batch
            if (!messageBatch.TryAddMessage(new ServiceBusMessage(_dealFactory.CreateSerializedDeal(order))))
            {
                // if an exception occurs
                throw new Exception($"Exception {order} has occurred.");
            }
        }

        // Use the producer client to send the batch of messages to the Service Bus queue
        await sender.SendMessagesAsync(messageBatch);
        Console.WriteLine($"A batch of {numberOfMessagesToSend} messages has been published to the queue.");
    }
}