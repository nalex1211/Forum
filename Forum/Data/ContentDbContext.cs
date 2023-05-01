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
}
