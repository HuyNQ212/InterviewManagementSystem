using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly InterviewManagementContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(InterviewManagementContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IBaseRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new BaseRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
