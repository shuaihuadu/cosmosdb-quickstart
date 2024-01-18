namespace CosmosDbExamples.Context;

public class ToDoItemDbContextFactory : IToDoItemDbContextFactory
{
    private readonly CosmosDbOptions _cosmosDbOptions;

    public ToDoItemDbContextFactory(IOptions<CosmosDbOptions> options)
    {
        _cosmosDbOptions = options.Value;
    }

    public ToDoItemDbContext Build()
    {
        return new ToDoItemDbContext(_cosmosDbOptions.ConnectionString, _cosmosDbOptions.DatabaseName, nameof(ToDoItem));
    }
}
