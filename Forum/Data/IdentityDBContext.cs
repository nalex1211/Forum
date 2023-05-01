using Forum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data;

public class IdentityDBContext : IdentityDbContext<ApplicationUsers>
{
    public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
    {
    }
}
