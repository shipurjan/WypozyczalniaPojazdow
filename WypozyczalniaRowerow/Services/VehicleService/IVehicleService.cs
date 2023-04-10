using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.VehicleService;

public interface IVehicleService
{
   IQueryable<Vehicle> GetAll();
   Vehicle Get(int id);
   IQueryable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate);
   void Add(Vehicle vehicle);
   void Edit(Vehicle vehicle);
   void Delete(Vehicle vehicle);
   void Save();
}