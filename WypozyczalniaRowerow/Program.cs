using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Models;
using WypozyczalniaRowerow.Services.RentingLocationService;
using WypozyczalniaRowerow.Services.VehicleService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ATHRentingSystem"));

builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IRentingLocationService, RentingLocationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//
// ----- populate database with dummy data
//
var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "ATHRentingSystem")
        .Options;
using (var context = new ApplicationDbContext(options))
{
    var vehicle_types = new List<VehicleType>
    {
        new VehicleType { Id = 1, Name = "Rower" },
        new VehicleType { Id = 2, Name = "Hulajnoga" },
    };

    foreach (var vehicle_type in vehicle_types)
    {
        context.VehicleTypes.Add(vehicle_type);
    }

    var vehicles = new List<Vehicle>
    {
        new Vehicle
        {
            Id = 1, Brand = "FSDSF", Type = vehicle_types[0], Color = "Red", Description = "asdfsdafs",
            IntendedTarget = "Męski", PictureHref = "."
        },
        new Vehicle
        {
            Id = 2, Brand = "SDFSS", Type = vehicle_types[1], Color = "Blue", Description = "asdfsdaf",
            IntendedTarget = "Damski", PictureHref = "."
        },
    };

    foreach (var vehicle in vehicles)
    {
        context.Vehicles.Add(vehicle);
    }

    var renting_locations = new List<RentingLocation>
    {
        new RentingLocation
        {
            Id = 1, Address = "ul. Willowa 10", City = "Bielsko-Biała",
            AvailableVehicles = new List<Vehicle> { vehicles[0] }
        },
        new RentingLocation
        {
            Id = 2, Address = "ul. Mickiewicza 16", City = "Bielsko-Biała",
            AvailableVehicles = new List<Vehicle> { vehicles[1] }
        },
    };

    foreach (var renting_location in renting_locations)
    {
        context.RentingLocations.Add(renting_location);
    }

    var reservations = new List<Reservation>
    {
        new Reservation
        {
            Id = 1, ReservationDate = new DateTime(2023, 4, 11, 14, 00, 00), ReservedVehicle = vehicles[0],
            ClientName = "Jan Bruk"
        },
        new Reservation
        {
            Id = 2, ReservationDate = new DateTime(2023, 4, 12, 16, 00, 00), ReservedVehicle = vehicles[1],
            ClientName = "Anna Truszkowska"
        },
    };

    foreach (var reservation in reservations)
    {
        context.Reservations.Add(reservation);
    }

    context.SaveChanges();
}
//
// ----- populate database with dummy data
//

app.Run();