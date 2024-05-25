using Microsoft.EntityFrameworkCore;
using Notess.Data.Tables;

namespace Notess.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; } = null!;

    public DbSet<TodoModel> Todos { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<UserModel>()
            .HasMany(e => e.TodoItems)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}