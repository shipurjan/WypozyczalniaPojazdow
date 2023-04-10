using WypozyczalniaRowerow.Data;

namespace WypozyczalniaRowerow.Services.VehicleService;

public class VehicleService : IVehicleService
{
   private VehicleContext _context;

   public VehicleService(VehicleContext context)
   {
      _context = context;
   }
   IQueryable<Vehicle> GetAll();
   Vehicle Get(int id);
   IQueryable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate);
   void Add(Vehicle vehicle);
   void Edit(Vehicle vehicle);
   void Delete(Vehicle vehicle);
   void Save();
}