namespace CosmosDbExamples.Context;

public class ToDoListDbContextFactory : IToDoListDbContextFactory
{
    private readonly CosmosDbOptions _cosmosDbOptions;

    public ToDoListDbContextFactory(IOptions<CosmosDbOptions> options)
    {
        this._cosmosDbOptions = options.Value;
    }

    public ToDoListDbContext Build()
    {
        return new ToDoListDbContext(this._cosmosDbOptions.ConnectionString, this._cosmosDbOptions.DatabaseName, nameof(ToDoItem));
    }
}
