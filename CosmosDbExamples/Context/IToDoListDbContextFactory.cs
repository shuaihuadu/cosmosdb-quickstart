namespace CosmosDbExamples.Context;

public interface IToDoListDbContextFactory
{
    ToDoListDbContext Build();
}
