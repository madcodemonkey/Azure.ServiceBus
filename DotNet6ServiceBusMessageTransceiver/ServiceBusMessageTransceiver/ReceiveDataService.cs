using Azure.Messaging.ServiceBus;

namespace ServiceBusMessageTransceiver;

public class ReceiveDataService
{
    private readonly ServiceBusClient _client;
    private readonly string _queueName;

    public ReceiveDataService(ServiceBusClient client, string queueName)
    {
        _client = client;
        _queueName = queueName;
    }

    public async Task WorkAsync()
    {
        await using var processor = _client.CreateProcessor(_queueName, new ServiceBusProcessorOptions());

        // add handler to process messages
        processor.ProcessMessageAsync += MessageHandler;

        // add handler to process any errors
        processor.ProcessErrorAsync += ErrorHandler;

        // start processing 
        await processor.StartProcessingAsync();

        Console.WriteLine("Wait for a minute and then press any key to end the processing");
        Console.ReadKey();

        // stop processing 
        Console.WriteLine("\nStopping the receiver...");
        await processor.StopProcessingAsync();
        Console.WriteLine("Stopped receiving messages");
    }


    // handle received messages
    static async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        Console.WriteLine($"Received: {body}");

        // complete the message. messages is deleted from the queue. 
        await args.CompleteMessageAsync(args.Message);
    }

    // handle any errors when receiving messages
    static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }

}