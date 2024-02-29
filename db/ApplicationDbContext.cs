using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using working_with_db.db.entities;

namespace working_with_db.db;

public class ApplicationDbContext : DbContext
{
    public DbSet<TypeDb> Types { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}