using System.Collections.Immutable;
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
    IQueryable<RentingLocation> GetAll();
    RentingLocation Get(int id);
    IQueryable<RentingLocation> FindBy(Expression<Func<RentingLocation, bool>> predicate);
    void Add(RentingLocation rentingLocation);
    void Edit(RentingLocation rentingLocation);
    void Delete(RentingLocation rentingLocation);
    void Save();
}