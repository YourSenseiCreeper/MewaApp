using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Repository;

namespace MewaAppBackend.WebApi.UnitOfWork
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private readonly Context db;
        private bool disposed = false;
        public Dictionary<System.Type, object> repositories = new();

        public GenericUnitOfWork(Context _db)
        {
            db = _db;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.TryGetValue(typeof(T), out var repository))
                return (IRepository<T>) repository;
            IRepository<T> repo = new Repository<T>(db);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
