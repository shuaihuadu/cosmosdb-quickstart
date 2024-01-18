namespace CosmosDbExamples.Services;

public class ToDoItemService
{
    private readonly IToDoItemDbContextFactory _dbContextFactory;

    public ToDoItemService(IToDoItemDbContextFactory dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
    }

    public async Task<ToDoItem> GetFirstItemAsync()
    {
        using (ToDoItemDbContext context = this.CreateDbContext())
        {
            return await context.ToDoItems.FirstAsync();
        }
    }

    public async Task AddItemAsync(ToDoItem item)
    {
        using (ToDoItemDbContext context = this.CreateDbContext())
        {
            //await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            context.ToDoItems.Add(item);

            await context.SaveChangesAsync();
        }
    }

    private ToDoItemDbContext CreateDbContext()
    {
        return _dbContextFactory.Build();
    }
}
