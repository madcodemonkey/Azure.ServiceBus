namespace ServiceBusMessageTransceiver;

public class ServerBusSettings
{
    public const string SectionName = "ServerBusOptions";

    public string ConnectionString { get; set; } = string.Empty;
    public string QueueName { get; set; } = string.Empty;
}