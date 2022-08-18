using ConsoleMenuHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ServiceBusMessageTransceiver;


try
{
    var menu = new ConsoleMenu();

    menu.AddDependencies(AddMyDependencies);
    menu.AddMenuItemViaReflection(Assembly.GetExecutingAssembly());

    await menu.DisplayMenuAsync("Main", "Main");

    Console.WriteLine("Done!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}

Console.WriteLine("Hit enter to exit");
Console.ReadLine();


static void AddMyDependencies(IServiceCollection serviceCollection)
{

    // IConfiguration requires: Microsoft.Extensions.Configuration NuGet package
    // AddJsonFile requires:    Microsoft.Extensions.Configuration.Json NuGet package
    // https://stackoverflow.com/a/46437144/97803
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddUserSecrets(typeof(SendQueueDealItemsMenuItem).Assembly);

    IConfiguration config = builder.Build();

    serviceCollection.AddSingleton<IConfiguration>(config);
}
