namespace CosmosDbExamples.Context;

public interface IToDoItemDbContextFactory
{
    ToDoItemDbContext Build();
}
