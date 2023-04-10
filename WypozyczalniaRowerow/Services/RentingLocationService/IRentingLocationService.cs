using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.RentingLocationService;

public interface IRentingLocationService
{   
    IQueryable<RentingLocation> GetAll();
    RentingLocation Get(int id);
    IQueryable<RentingLocation> FindBy(Expression<Func<RentingLocation, bool>> predicate);
    void Add(RentingLocation rentingLocation);
    void Edit(RentingLocation rentingLocation);
    void Delete(RentingLocation rentingLocation);
    void Save();
}