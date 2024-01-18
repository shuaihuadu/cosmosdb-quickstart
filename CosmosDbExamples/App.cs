namespace CosmosDbExamples;

internal class App
{
    private readonly ToDoListService _todoListService;

    public App(ToDoListService qnaService)
    {
        this._todoListService = qnaService;
    }

    public async Task RunAsync(string[] args)
    {
        string id = Guid.NewGuid().ToString();

        ToDoItem item = new()
        {
            Id = id,
            Content = "Content " + id.ToString()
        };

        await _todoListService.AddToDoItemAsync(item);

        ToDoItem? qnaInDb = await _todoListService.GetToDoItemByIdAsync(item.Id);

        Console.WriteLine(qnaInDb?.Content);
        Console.WriteLine("==========");
    }
}
