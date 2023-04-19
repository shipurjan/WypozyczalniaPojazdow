using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Models;
using WypozyczalniaRowerow.Services.RentingLocationService;
using WypozyczalniaRowerow.Services.VehicleService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ATHRentingSystem"));

var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseInMemoryDatabase(databaseName: "ATHRentingSystem")
    .Options;

using (var context = new ApplicationDbContext(options)) {
    context.Database.EnsureCreated();
    context.SaveChanges();
}

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IRentingLocationService, RentingLocationService>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    }
);

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

app.Run();