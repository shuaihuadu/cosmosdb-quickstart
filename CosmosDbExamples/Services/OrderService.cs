namespace CosmosDbExamples.Services;

public class OrderService
{
    private readonly IOptions<CosmosDbOptions> _options;

    public OrderService(IOptions<CosmosDbOptions> options)
    {
        this._options = options;
    }

    public async Task<Order> GetFirstItemAsync()
    {
        using (OrderContext context = new(this._options))
        {
            return await context.Orders.FirstAsync();
        }
    }

    public async Task AddItemAsync(Order item)
    {
        using (OrderContext context = new(this._options))
        {
            //await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            context.Add(item);

            await context.SaveChangesAsync();
        }
    }
}
