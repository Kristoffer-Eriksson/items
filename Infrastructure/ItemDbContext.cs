using Microsoft.EntityFrameworkCore;

namespace items.Infrastructure;

public class ItemDbContext : DbContext
{
    public ItemDbContext(DbContextOptions<ItemDbContext> options)
        : base(options)
    { }
    
    public DbSet<Item> Items { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Item>()
            .Property(x => x.Description)
            .HasMaxLength(256);
    }
}