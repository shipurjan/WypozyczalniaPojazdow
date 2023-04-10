using System.Linq.Expressions;

namespace WypozyczalniaRowerow.Services;

public interface IRepositoryService<T> where T : class
{
    IQueryable<T> GetAll();
    T GetById(object id);
    
    void Add(T rentingLocation);
    void Edit(T rentingLocation);
    void Delete(object obj);
    void Save();
    
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
}