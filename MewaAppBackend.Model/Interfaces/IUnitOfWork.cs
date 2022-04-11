using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Model.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
