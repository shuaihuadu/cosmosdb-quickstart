IServiceCollection services = new ServiceCollection();

services.ConfigureServices();

using (ServiceProvider serviceProvider = services.BuildServiceProvider())
{
    App app = serviceProvider.GetRequiredService<App>();

    await app.RunAsync(args);
}
