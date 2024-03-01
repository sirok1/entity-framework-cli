using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using working_with_db.db.entities;

namespace working_with_db.db;

public class ApplicationDbContext : DbContext
{
    public DbSet<TypeDb> Types { get; set; } = null!;

    public ApplicationDbContext()
    {
        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");
        DotEnv.Load(dotenv);
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql( $"Host={Environment.GetEnvironmentVariable("DB_HOST")};Port={Environment.GetEnvironmentVariable("DB_PORT")};Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}");
    }
}