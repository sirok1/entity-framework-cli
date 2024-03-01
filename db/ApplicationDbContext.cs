using Microsoft.EntityFrameworkCore;
using Entity_framework_cli.db.entities;
using Entity_framework_cli.utils;

namespace Entity_framework_cli.db;

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
            .HasOne(b => b.district)
            .WithMany(a => a.propertyObjects)
            .HasForeignKey(b => b.districtId);
        modelBuilder.Entity<PropertyObject>()
            .HasOne(b => b.type)
            .WithMany(a => a.propertyObjects)
            .HasForeignKey(b => b.typeId);
        modelBuilder.Entity<PropertyObject>()
            .HasOne(b => b.material)
            .WithMany(a => a.propertyObjects)
            .HasForeignKey(b => b.materialId);
        modelBuilder.Entity<Estimates>()
            .HasOne(b => b.propertyObject)
            .WithMany(a => a.estimates)
            .HasForeignKey(b => b.propertyObjectId);
        modelBuilder.Entity<Estimates>()
            .HasOne(b => b.criteria)
            .WithMany(a => a.estimates)
            .HasForeignKey(b => b.creteriaId);
        modelBuilder.Entity<Selling>()
            .HasOne(b => b.agnet)
            .WithMany(a => a.sellings)
            .HasForeignKey(b => b.agentId);
    }
}