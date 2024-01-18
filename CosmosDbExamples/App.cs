namespace CosmosDbExamples;

internal class App
{
    private readonly OrderService _orderService;
    private readonly ToDoItemService _toDoItemService;

    public App(OrderService qnaService, ToDoItemService toDoItemService)
    {
        this._orderService = qnaService;
        this._toDoItemService = toDoItemService;
    }

    public async Task RunAsync(string[] args)
    {
        int id = DateTime.Now.Microsecond;
        Order item = new()
        {
            Id = id,
            ShippingAddress = new StreetAddress { City = "London", Street = "221 B Baker St" },
            PartitionKey = id.ToString()
        };

        await _orderService.AddItemAsync(item);

        Order? itemInDb = await _orderService.GetFirstItemAsync();

        Console.WriteLine("Order Id:" + itemInDb?.Id);
        Console.WriteLine("====================");


        ToDoItem toDoItem = new()
        {
            Id = Guid.NewGuid().ToString(),
            Content = "Content " + Guid.NewGuid().ToString()
        };

        await this._toDoItemService.AddItemAsync(toDoItem);

        ToDoItem toDoItemInDb = await this._toDoItemService.GetFirstItemAsync();

        Console.WriteLine(toDoItemInDb?.Id);
    }
}
