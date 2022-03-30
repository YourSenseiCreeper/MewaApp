using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MewaAppBackend.Model.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
