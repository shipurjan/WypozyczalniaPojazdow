using System.Linq.Expressions;

namespace WypozyczalniaRowerow.Services;

public interface IRepositoryService<T> where T : class
{
    IQueryable<T> GetAll();
    T GetById(int id);
    
    void Add(T rentingLocation);
    void Edit(T rentingLocation);
    void Delete(int id);
    void Delete(T entity);
    void Save();
    
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
}