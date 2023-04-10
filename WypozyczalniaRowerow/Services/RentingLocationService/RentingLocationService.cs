using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.RentingLocationService;

public class RentingLocationService : IRentingLocationService
{
    private ApplicationDbContext _context;

    public RentingLocationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<RentingLocation> GetAll()
    {
        return _context.RentingLocations.AsQueryable<RentingLocation>();
    }

    public RentingLocation Get(int id)
    {
      return _context.RentingLocations.FirstOrDefault(r => r.Id == id);
    }

    public IQueryable<RentingLocation> FindBy(Expression<Func<RentingLocation, bool>> predicate)
    {
      return _context.RentingLocations.AsQueryable<RentingLocation>().Where(predicate);
    }

    public void Add(RentingLocation rentingLocation)
    { 
        _context.RentingLocations.Add(rentingLocation);
    }

    public void Edit(RentingLocation rentingLocation)
    {
        _context.RentingLocations.Update(rentingLocation);
    }

    public void Delete(RentingLocation rentingLocation)
    {
        _context.RentingLocations.Remove(rentingLocation);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

}