using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MewaAppBackend.WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly Context db;
        private readonly DbSet<T> _objectSet;
        public Repository(Context _db)
        {
            db = _db;
            _objectSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
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
            return _objectSet.First(predicate);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            return this.GetAll().IncludeMultiple(includes);
        }

        public T GetDetail(int id)
        {
            return _objectSet.First(x => x.Id == id);
        }
    }
}
