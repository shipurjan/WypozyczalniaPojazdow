using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<RentingLocation> RentingLocations { get; set; }
}