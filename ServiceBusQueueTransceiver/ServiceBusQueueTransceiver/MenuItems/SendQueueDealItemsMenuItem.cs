using ConsoleMenuHelper;

namespace ServiceBusMessageTransceiver;

[ConsoleMenuItem("Main", 1)]
public class SendQueueDealItemsMenuItem : IConsoleMenuItem
{
    private readonly IPromptHelper _promptHelper;
    private readonly ISendDataService _sendDataService;

    /// <summary>Constructor</summary>
    public SendQueueDealItemsMenuItem(ISendDataService sendDataService, IPromptHelper promptHelper)
    {
        _sendDataService = sendDataService;
        _promptHelper = promptHelper;
    }

    public async Task<ConsoleMenuItemResponse> WorkAsync()
    {
        var numberToSend = _promptHelper.GetNumber("How many messages do you want to send (0, 50)", 0, 50, "exit", 0);

        if (numberToSend.HasValue && numberToSend.Value > 0)
        {
            await _sendDataService.WorkAsync(numberToSend.Value);
        }
        return new ConsoleMenuItemResponse(false, false);
    }

    public string ItemText => "Send Deal message(s) to queue";
    public string AttributeData { get; set; } = string.Empty;
}