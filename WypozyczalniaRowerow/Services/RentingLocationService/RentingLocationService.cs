using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.RentingLocationService;

public class RentingLocationService : IRentingLocationService
{
    private RentingLocationContext _context;

    public RentingLocationService(RentingLocationContext context)
    {
        _context = context;
    }

    public IQueryable<RentingLocation> GetAll()
    {
        throw new NotImplementedException();
    }

    public RentingLocation Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<RentingLocation> FindBy(Expression<Func<RentingLocation, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Add(RentingLocation rentingLocation)
    {
        throw new NotImplementedException();
    }

    public void Edit(RentingLocation rentingLocation)
    {
        throw new NotImplementedException();
    }

    public void Delete(RentingLocation rentingLocation)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

}