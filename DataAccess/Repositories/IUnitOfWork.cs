using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        void SaveChanges();

    }
}
