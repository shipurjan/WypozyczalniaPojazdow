using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<RentingLocation> RentingLocations { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .HasOne(_ => _.Type)
            .WithMany(a => a.Vehicles)
            .HasForeignKey(p => p.VehicleTypeId);
    }
}