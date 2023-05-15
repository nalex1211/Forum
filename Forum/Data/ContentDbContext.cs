using Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data;

public class ContentDbContext : DbContext
{

    public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
    {
    }

    public DbSet<Comments> Comments { get; set; }
    public DbSet<Discussions> Discussions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<ApplicationUsers>();
        modelBuilder.Entity<Discussions>()
           .HasMany(d => d.Comments)
           .WithOne(c => c.Discussions)
           .OnDelete(DeleteBehavior.Cascade);
    }
}

