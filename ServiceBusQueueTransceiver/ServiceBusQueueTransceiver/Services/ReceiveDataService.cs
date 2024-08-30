using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace ServiceBusMessageTransceiver;

public class ReceiveDataService : IReceiveDataService
{
    private readonly ServerBusSettings _settings;
    
    /// <summary>
    /// Constructor
    /// </summary>
    public ReceiveDataService(IOptions<ServerBusSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task WorkAsync()
    {
        await using ServiceBusClient client = new ServiceBusClient(_settings.ConnectionString);
        
        await using var processor = client.CreateProcessor(_settings.QueueName, new ServiceBusProcessorOptions());

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