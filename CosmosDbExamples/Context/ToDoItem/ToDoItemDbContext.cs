namespace CosmosDbExamples.Context;

public class ToDoItemDbContext : DbContext
{
    private readonly string _databaseName;
    private readonly string _connectionString;
    private readonly string _containerName;

    public ToDoItemDbContext(string connectionString, string databaseName, string containerName)
    {
        _connectionString = connectionString;
        _databaseName = databaseName;
        _containerName = containerName;
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(_connectionString, _databaseName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultContainer(_containerName);
        modelBuilder.Entity<ToDoItem>()
            .ToContainer(_containerName)
            .HasPartitionKey(t => t.Id)
            .HasNoDiscriminator();
    }
}
