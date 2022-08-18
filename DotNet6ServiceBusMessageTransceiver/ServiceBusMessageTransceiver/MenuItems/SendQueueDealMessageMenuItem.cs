using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ConsoleMenuHelper;

namespace ServiceBusMessageTransceiver;

[ConsoleMenuItem("Main")]
public class SendQueueDealMessageMenuItem: IConsoleMenuItem
{
    private readonly IConsoleMenuController _controller;

    /// <summary>Constructor</summary>
    public SendQueueDealMessageMenuItem(IConsoleMenuController controller)
    {
        _controller = controller;
    }

    public async Task<ConsoleMenuItemResponse> WorkAsync()
    {
        await _controller.DisplayMenuAsync("QueueMessages", "Queue Send deal message", BreadCrumbType.Concatenate);
        return new ConsoleMenuItemResponse(false, true);
    }

    public string ItemText => "Queue messages";
    public string AttributeData { get; set; }
}