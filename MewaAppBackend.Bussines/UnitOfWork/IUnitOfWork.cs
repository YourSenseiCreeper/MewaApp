using MewaAppBackend.Business.Repository;

namespace MewaAppBackend.Business.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Dispose();
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
