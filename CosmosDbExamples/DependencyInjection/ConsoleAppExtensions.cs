namespace CosmosDbExamples.DependencyInjection;

public static class ConsoleAppExtensions
{

    public static void ConfigureServices(this IServiceCollection services)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", true, true)
            .Build();

        services.ConfigureConsoleApp(configuration).AddServices();

        services.AddLogging(builder =>
        {
            builder.AddConsole().SetMinimumLevel(LogLevel.Information);
        });
    }

    static IServiceCollection ConfigureConsoleApp(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.Configure<CosmosDbOptions>(configuration.GetSection(nameof(CosmosDbOptions)));
        services.AddTransient<App>();

        return services;
    }

    static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IToDoItemDbContextFactory, ToDoItemDbContextFactory>();
        services.AddSingleton<ToDoItemService>();
        services.AddSingleton<OrderService>();

        return services;
    }
}
