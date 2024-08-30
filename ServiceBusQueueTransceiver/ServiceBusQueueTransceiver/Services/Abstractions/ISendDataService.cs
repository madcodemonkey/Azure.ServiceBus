namespace ServiceBusMessageTransceiver;

public interface ISendDataService
{
    Task WorkAsync(int numberOfMessagesToSend);
}