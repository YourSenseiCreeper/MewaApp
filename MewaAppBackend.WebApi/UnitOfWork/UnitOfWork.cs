using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Repository;

namespace MewaAppBackend.WebApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context db = null;
        public UnitOfWork(Context _db)
        {
            db = _db;
        }
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;
            IRepository<T> repo = new Repository<T>(db);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            this.disposed = true;
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
