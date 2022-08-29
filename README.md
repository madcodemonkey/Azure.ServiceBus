# Azure Service Bus

## Projects List
- Service Bus Message Transceiver (ServiceBusMessageTransceiver) - This is a console application designed to 
    - Send Queue message to a service bus
    - Retrieve all the message from a queue on a service bus 
  
Notes
- See the readme.md file in each project for setup instructions.



## Create a **Standard** Tier Service Bus
<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3a%2f%2fraw.githubusercontent.com%2fmadcodemonkey%2fAzure.ServiceBus%2fmain%2fARM-Files%2fStandardServiceBus.json" target="_blank">
       <img src="https://aka.ms/deploytoazurebutton"/>
</a>


Notes
- Remember that Topics are only available at the Standard Tier and above.

## Create a **Basic** Service bus with a queue
<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3a%2f%2fraw.githubusercontent.com%2fmadcodemonkey%2fAzure.ServiceBus%2fmain%2fARM-Files%2fBasicServiceBusWithQueue.json" target="_blank">
       <img src="https://aka.ms/deploytoazurebutton"/>
</a>


Notes
- This service bus can only have queues since it is at the Basic level!  If you need Topics, create a Stanard Tier service bus.

## Branching scheme
- DotNet6: .NET Core 6.0 example
- [Future] I will create a branch for each version of .NET 

