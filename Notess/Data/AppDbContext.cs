using Microsoft.EntityFrameworkCore;
using Notess.Data.Tables;

namespace Notess.Data;

/// <summary>
/// Represents the application's database context.
/// </summary>
public sealed class AppDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet of UserModels in the database.
    /// </summary>
    public DbSet<UserModel> Users { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet of TodoModels in the database.
    /// </summary>
    public DbSet<TodoModel> Todos { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the AppDbContext class with the specified options.
    /// </summary>
    /// <param name="options">The DbContextOptions for the database context.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    /// <summary>
    /// Configures the relationships and constraints for the database entities.
    /// </summary>
    /// <param name="mb">The ModelBuilder instance used to configure the model.</param>
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<UserModel>()
            .HasMany(e => e.TodoItems)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}