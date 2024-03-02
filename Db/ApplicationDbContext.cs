using Microsoft.EntityFrameworkCore;
using Entity_framework_cli.Db.Entities;
using Entity_framework_cli.Utils;

namespace Entity_framework_cli.Db;

public class ApplicationDbContext : DbContext
{
    public DbSet<TypeDb> Types { get; set; } = null!;
    public DbSet<Selling> Sellings { get; set; } = null!;
    public DbSet<PropertyObject> PropertyObjects { get; set; } = null!;
    public DbSet<Estimates> Estimates { get; set; } = null!;
    public DbSet<EstateAgent> EstateAgents { get; set; } = null!;
    public DbSet<District> Districts { get; set; } = null!;
    public DbSet<BuildingMaterial> BuildingMaterials { get; set; } = null!;
    public DbSet<AssessmentCriteria> AssessmentCriterias { get; set; } = null!;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PropertyObject>()
            .HasOne(b => b.District)
            .WithMany(a => a.PropertyObjects)
            .HasForeignKey(b => b.DistrictId);
        modelBuilder.Entity<PropertyObject>()
            .HasOne(b => b.Type)
            .WithMany(a => a.PropertyObjects)
            .HasForeignKey(b => b.TypeId);
        modelBuilder.Entity<PropertyObject>()
            .HasOne(b => b.Material)
            .WithMany(a => a.PropertyObjects)
            .HasForeignKey(b => b.MaterialId);
        modelBuilder.Entity<Estimates>()
            .HasOne(b => b.PropertyObject)
            .WithMany(a => a.Estimates)
            .HasForeignKey(b => b.PropertyObjectId);
        modelBuilder.Entity<Estimates>()
            .HasOne(b => b.Criteria)
            .WithMany(a => a.Estimates)
            .HasForeignKey(b => b.CreteriaId);
        modelBuilder.Entity<Selling>()
            .HasOne(b => b.Agnet)
            .WithMany(a => a.Sellings)
            .HasForeignKey(b => b.AgentId);
    }
}