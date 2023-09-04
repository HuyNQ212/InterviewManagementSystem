using DataAccess.Models;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T? GetById(object id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        void Insert(T entity);
        void Insert(params T[] entities);
        void Update(T entity);
        void Delete(object? id);
        void Delete(T entity);
        void Save();

        T? FirstOrDefault(Expression<Func<T, bool>> filter);

        T? FirstOrDefaultInclude(Expression<Func<T, bool>> filter, params string[] includeProps);
    }
}
