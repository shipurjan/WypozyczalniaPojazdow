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
      throw new NotImplementedException();
   }

   public Vehicle Get(int id)
   {
      throw new NotImplementedException();
   }

   public IQueryable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate)
   {
      throw new NotImplementedException();
   }

   public void Add(Vehicle vehicle)
   {
      throw new NotImplementedException();
   }

   public void Edit(Vehicle vehicle)
   {
      throw new NotImplementedException();
   }

   public void Delete(Vehicle vehicle)
   {
      throw new NotImplementedException();
   }

   public void Save()
   {
      throw new NotImplementedException();
   }
}