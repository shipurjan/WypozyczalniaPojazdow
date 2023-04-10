using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Data;

namespace WypozyczalniaRowerow.Services;

public class RepositoryService<T> : IRepositoryService<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public RepositoryService(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }


    public virtual IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable<T>();
    }

    public virtual T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Edit(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    public virtual void Delete(int id)
    {
        Delete(_dbSet.Find(id));
    }
    
    public virtual void Save()
    {
        _context.SaveChanges();
    }

    public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AsQueryable<T>().Where(predicate);
    }
}