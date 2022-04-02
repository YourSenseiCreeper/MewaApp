using System.Linq.Expressions;

namespace MewaAppBackend.Model.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        T GetDetail(int id);
        T GetDetail(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
