using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WypozyczalniaRowerow.Areas.Identity.Data;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
     
     public DbSet<Vehicle> Vehicles { get; set; }
     public DbSet<VehicleType> VehicleTypes { get; set; }
     public DbSet<RentingLocation> RentingLocations { get; set; }
     public DbSet<Reservation> Reservations { get; set; }
     
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         modelBuilder.Entity<Vehicle>().HasKey(m => m.Id);
         modelBuilder.Entity<VehicleType>().HasKey(m => m.Id);
         modelBuilder.Entity<RentingLocation>().HasKey(m => m.Id);
         modelBuilder.Entity<Reservation>().HasKey(m => m.Id);
         modelBuilder.Entity<Vehicle>().HasData(GetVehicles());
         modelBuilder.Entity<VehicleType>().HasData(GetVehicleTypes());
         modelBuilder.Entity<RentingLocation>().HasData(GetRentingLocations());
         modelBuilder.Entity<Reservation>().HasData(GetReservations());

         modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
             
         base.OnModelCreating(modelBuilder);
         
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
                 Street = $"Willowa {index}",
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
                 ReservationDate = DateTime.Now,
                 RentingLocationId = rnd.Next(1,10),
                 VehicleId = rnd.Next(1,10)
             })
             .ToList();
     }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(63);
        builder.Property(u => u.LastName).HasMaxLength(63);
    }
}
