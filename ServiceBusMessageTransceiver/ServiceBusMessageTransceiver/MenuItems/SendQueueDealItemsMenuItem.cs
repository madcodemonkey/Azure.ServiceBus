using Azure.Messaging.ServiceBus;
using ConsoleMenuHelper;
using Microsoft.Extensions.Configuration;

namespace ServiceBusMessageTransceiver;

[ConsoleMenuItem("Main", 1)]
public class SendQueueDealItemsMenuItem : IConsoleMenuItem
{
    private readonly IConfiguration _configuration;
    private readonly IPromptHelper _promptHelper;

    /// <summary>Constructor</summary>
    public SendQueueDealItemsMenuItem(IConfiguration configuration, IPromptHelper promptHelper)
    {
        _configuration = configuration;
        _promptHelper = promptHelper;
    }
    public async Task<ConsoleMenuItemResponse> WorkAsync()
    {
        string connectionString = _configuration["ServiceBusConnectionString"];
        string queueName = _configuration["ServiceBusDealQueueName"];

        var numberToSend = _promptHelper.GetNumber("How many messages do you want to send (0, 50)", 0, 50, "exit", 0);

        if (numberToSend.HasValue && numberToSend.Value > 0)
        {
            await using (var client = new ServiceBusClient(connectionString))
            {
                var sender = new SendDataService(client, queueName);
                await sender.WorkAsync(numberToSend.Value);
            }
        }

        return new ConsoleMenuItemResponse(false, false);
    }

    public string ItemText => "Send Deal message(s)";
    public string AttributeData { get; set; }

}