using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MewaAppBackend.Model.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetDetail(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
