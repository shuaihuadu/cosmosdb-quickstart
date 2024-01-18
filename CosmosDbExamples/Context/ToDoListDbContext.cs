namespace CosmosDbExamples.Context;

public class ToDoListDbContext : DbContext
{
    private readonly string _databaseName;
    private readonly string _connectionString;
    private readonly string _containerName;

    public ToDoListDbContext(string connectionString, string databaseName, string containerName)
    {
        this._connectionString = connectionString;
        this._databaseName = databaseName;
        this._containerName = containerName;
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(this._connectionString, this._databaseName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultContainer(this._containerName);
        modelBuilder.Entity<ToDoItem>()
            .ToContainer(this._containerName)
            //.HasPartitionKey(t => t.Id)
            .HasNoDiscriminator();
    }
}
