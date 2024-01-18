namespace CosmosDbExamples.Context;

public class OrderContext : DbContext
{
    private readonly CosmosDbOptions _options;

    public DbSet<Order> Orders { get; set; }

    public OrderContext(IOptions<CosmosDbOptions> options) : base()
    {
        this._options = options.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(_options.ConnectionString, _options.DatabaseName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultContainer("Store");

        modelBuilder.Entity<Order>().ToContainer("Orders")
            .HasNoDiscriminator()
            .HasPartitionKey(o => o.PartitionKey);

        modelBuilder.Entity<Order>()
            .UseETagConcurrency();

        modelBuilder.Entity<Order>().OwnsOne(
            o => o.ShippingAddress,
            sa =>
            {
                sa.ToJsonProperty("Address");
                sa.Property(p => p.Street).ToJsonProperty("ShipsToStreet");
                sa.Property(p => p.City).ToJsonProperty("ShipsToCity");
            });

        modelBuilder.Entity<Distributor>().OwnsMany(p => p.ShippingCenters);

        modelBuilder.Entity<Distributor>()
            .Property(d => d.ETag)
            .IsETagConcurrency();
    }
}
