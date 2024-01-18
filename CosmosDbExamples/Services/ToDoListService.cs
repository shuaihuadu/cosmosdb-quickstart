namespace CosmosDbExamples.Services;

public class ToDoListService
{
    private readonly IToDoListDbContextFactory _dbContextFactory;

    public ToDoListService(IToDoListDbContextFactory dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
    }

    public async Task<ToDoItem> GetToDoItemByIdAsync(string id)
    {
        using (ToDoListDbContext context = CreateDbContext())
        {
            context.Database.EnsureCreated();
            return await context.ToDoItems.FirstAsync(q => q.Id == id);
        }
    }

    public async Task AddToDoItemAsync(ToDoItem item)
    {
        using (ToDoListDbContext context = CreateDbContext())
        {
            //context.Database.EnsureCreated();

            context.Add(item);

            await context.SaveChangesAsync();
        }
    }

    private ToDoListDbContext CreateDbContext()
    {
        return _dbContextFactory.Build();
    }
}
