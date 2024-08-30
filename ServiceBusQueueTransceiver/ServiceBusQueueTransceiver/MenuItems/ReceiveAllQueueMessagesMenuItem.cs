using ConsoleMenuHelper;

namespace ServiceBusMessageTransceiver;

[ConsoleMenuItem("Main", 2)]
public class ReceiveAllQueueMessagesMenuItem : IConsoleMenuItem
{
    private readonly IReceiveDataService _receiveDataService;

    /// <summary>Constructor</summary>
    public ReceiveAllQueueMessagesMenuItem(IReceiveDataService receiveDataService)
    {
        _receiveDataService = receiveDataService;
    }

    public async Task<ConsoleMenuItemResponse> WorkAsync()
    {
        await _receiveDataService.WorkAsync();

        return new ConsoleMenuItemResponse(false, false);
    }

    public string ItemText => "Retrieve all Deal messages from queue";
    public string AttributeData { get; set; } = string.Empty;
}