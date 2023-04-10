using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.VehicleService;

public class VehicleService : IVehicleService
{
   private VehicleContext _context;

   public VehicleService(VehicleContext context)
   {
      _context = context;
   }

   public IQueryable<Vehicle> GetAll()
   {
      return _context.Vehicles.AsQueryable<Vehicle>();
   }

   public Vehicle Get(int id)
   {
      return _context.Vehicles.FirstOrDefault(r => r.Id == id);
   }

   public IQueryable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate)
   {
      return _context.Vehicles.AsQueryable<Vehicle>().Where(predicate);
   }

   public void Add(Vehicle vehicle)
   {
      _context.Vehicles.Add(vehicle);
   }

   public void Edit(Vehicle vehicle)
   {
      _context.Vehicles.Update(vehicle);
   }

   public void Delete(Vehicle vehicle)
   {
      _context.Vehicles.Remove(vehicle);
   }

   public void Save()
   {
        _context.SaveChanges();
   }
}