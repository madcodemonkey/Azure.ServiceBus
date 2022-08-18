using Azure.Messaging.ServiceBus;
using ConsoleMenuHelper;
using Microsoft.Extensions.Configuration;

namespace ServiceBusMessageTransceiver;

[ConsoleMenuItem("QueueMessages")]
public class ReceiveAllQueueMessagesMenuItem : IConsoleMenuItem
{
    private readonly IConfiguration _configuration;

    /// <summary>Constructor</summary>
    public ReceiveAllQueueMessagesMenuItem(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<ConsoleMenuItemResponse> WorkAsync()
    {
        string connectionString = _configuration["ServiceBusConnectionString"];
        string queueName = _configuration["ServiceBusDealQueueName"];

        await using (var client = new ServiceBusClient(connectionString))
        {
            var receiver = new ReceiveDataService(client, queueName);
            await receiver.WorkAsync();
        }

        return new ConsoleMenuItemResponse(false, false);
    }

    public string ItemText => "Retrieve all Deal messages";
    public string AttributeData { get; set; }

}