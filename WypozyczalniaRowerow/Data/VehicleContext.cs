using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Data;

public class VehicleContext : DbContext
{
    public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
    {
    }
    public DbSet<Vehicle> Vehicles { get; set; }
}