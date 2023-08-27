using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Implement
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected internal readonly DbSet<T> dbSet;
        protected internal readonly InterviewManagementContext context;

        public BaseRepository(InterviewManagementContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual bool Delete(object id)
        {
            T? entityToDelete = dbSet.Find(id);

            if (entityToDelete != null)
            {
                entityToDelete.IsActive = false;
                entityToDelete.UpdatedAt = DateTime.Now;
                context.Entry(entityToDelete).State = EntityState.Modified;
                return true;
            }

            return false;
        }

        public virtual T? GetById(object id)
        {
            T? entity = dbSet.Find(id);

            if (entity != null && entity.IsActive == true)
            {
                return entity;
            }

            return null;
        }

        public virtual void Insert(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.CreatedAt = DateTime.Now;
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual bool Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
                return false;
            }

            entity.IsActive = false;
            entity.UpdatedAt = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet.Where(t => t.IsActive == true);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Insert(params T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                dbSet.Add(entities[i]);
            }
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}
