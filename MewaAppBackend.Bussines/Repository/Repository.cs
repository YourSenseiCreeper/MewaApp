using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MewaAppBackend.WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context db;
        private readonly DbSet<T> _objectSet;
        public Repository(Context _db)
        {
            db = _db;
            _objectSet = db.Set<T>();
        }

        public DbSet<T> ObjectSet
        {
            get { return _objectSet; }
        }

        public T Add(T entity)
        {
            return _objectSet.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            _objectSet.Update(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _objectSet.AsQueryable();
        }

        public T GetDetail(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            return GetAll().IncludeMultiple(includes);
        }
    }
}
