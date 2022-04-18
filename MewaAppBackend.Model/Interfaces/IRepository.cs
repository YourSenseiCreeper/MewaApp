using System.Linq.Expressions;

namespace MewaAppBackend.Model.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        T GetDetail(Func<T, bool> predicate);
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
