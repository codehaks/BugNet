using BugNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BugNet.Data;

public class BugDbContext:DbContext
{
    public BugDbContext(DbContextOptions<BugDbContext> options)
           : base(options)
    {
    }

    public DbSet<Bug> Bugs { get; set; }
}
