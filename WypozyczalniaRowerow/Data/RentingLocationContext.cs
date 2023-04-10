using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Data;

public class RentingLocationContext : DbContext
{
    public RentingLocationContext(DbContextOptions<RentingLocationContext> options) : base(options)
    {
    }
    public DbSet<RentingLocation> RentingLocations { get; set; }
}