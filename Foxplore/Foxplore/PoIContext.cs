using Microsoft.EntityFrameworkCore;

namespace Foxplore;

public class PoIContext : DbContext
{
    public PoIContext(DbContextOptions<PoIContext> options) : base(options)
    {
    }   
    public DbSet<PointsOfInterest.Park> Parks { get; set; }
    public DbSet<PointsOfInterest.Viewpoint> ViewPoints { get; set; }
    public DbSet<PointsOfInterest.TechnicalFeature> TechnicalFeatures { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PointsOfInterest.Park>().ToTable("Park").HasNoKey();
        modelBuilder.Entity<PointsOfInterest.Viewpoint>().ToTable("ViewPoint").HasNoKey();
        modelBuilder.Entity<PointsOfInterest.TechnicalFeature>().ToTable("TechnicalFeature").HasNoKey();
    }
}