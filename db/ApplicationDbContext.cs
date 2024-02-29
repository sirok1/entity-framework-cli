using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using working_with_db.db.entities;

namespace working_with_db.db;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _config;

    public DbSet<TypeDb> Types { get; set; } = null!;

    public ApplicationDbContext(IConfiguration config)
    {
        _config = config;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={_config["DB_HOST"]};Port={_config["DB_PORT"]};Database={_config["POSTGRES_DB"]};Username={_config["POSTGRES_USER"]};Password={_config["POSTGRES_PASSWORD"]}");
    }
}