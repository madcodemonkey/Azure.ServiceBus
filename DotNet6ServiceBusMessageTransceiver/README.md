# ServiceBus Message Transceiver
This program is designed to send and receive messages to/from a Service Bus.

Currently it will send the Deal.cs class (under Data folder) to the service bus queue specified in the appsettings.json file.

# Changes you need to make
1. Add the connection string for your service bus to the appsettings.json file.
2. Add the name of you your queue in the service bus to the appsettings.json file.


# Deploy a Standard Service Bus
<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Fservicebus%2FMicrosoft.Azure.ServiceBus%2Fassets%2Fazure-deploy-test-dependencies.json" target="_blank">
       <img src="https://aka.ms/deploytoazurebutton"/>
</a>