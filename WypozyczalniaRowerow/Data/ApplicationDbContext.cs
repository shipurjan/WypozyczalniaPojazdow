using System.Collections.Immutable;
using System.Configuration;
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
        modelBuilder.Entity<Vehicle>().HasData(GetVehicles());
        modelBuilder.Entity<VehicleType>().HasData(GetVehicleTypes());
        modelBuilder.Entity<RentingLocation>().HasData(GetRentingLocations());
        modelBuilder.Entity<Reservation>().HasData(GetReservations());
        /*
        modelBuilder.Entity<Vehicle>()
            .HasOne(_ => _.Type)
            .WithMany(a => a.Vehicles)
            .HasForeignKey(p => p.VehicleTypeId);
        */
    }

    private List<VehicleType> GetVehicleTypes()
    {
        return Enumerable.Range(1, 10)
            .Select(index => new VehicleType
            {
                Id = index,
                Name = $"TYPE_{index}"
            })
            .ToList();
    }

    private List<Vehicle> GetVehicles()
    {
        Random rnd = new Random();
        return Enumerable.Range(1, 10)
            .Select(index => new Vehicle
            {
                Id = index,
                VehicleTypeId = rnd.Next(1, 10),
                RentingLocationId = rnd.Next(1,10),
                Brand = $"BRAND_{index}",
                Color = $"Black_{index}",
                Description = $"{index}asdfsdfsdf",
                IntendedTarget = $"{index}Męski",
                PictureHref = ".",
            })
            .ToList();
    }
    private List<RentingLocation> GetRentingLocations()
    {
        return Enumerable.Range(1, 10)
            .Select(index => new RentingLocation
            {
                Id = index,
                Address = $"Willowa {index}",
                City = "Bielsko-Biała",
                
            })
            .ToList();
    }
    private List<Reservation> GetReservations()
    {
        Random rnd = new Random();
        return Enumerable.Range(1, 10)
            .Select(index => new Reservation
            {
                Id = index,
                ClientName = $"{index}Aasd Korr",
                ReservationDate = DateTime.Today,
                RentingLocationId = rnd.Next(1,10),
                VehicleId = rnd.Next(1,10)
            })
            .ToList();
    }
}