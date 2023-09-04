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

        public virtual void Delete(object? id)
        {
            T? entityToDelete = dbSet.Find(id);

            if (entityToDelete != null)
            {
                entityToDelete.IsActive = false;
                entityToDelete.UpdatedAt = DateTime.Now;
                context.Entry(entityToDelete).State = EntityState.Modified;
            }
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

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            entity.IsActive = false;
            entity.UpdatedAt = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
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

        public T? FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(t => t.IsActive == true).FirstOrDefault(filter);
        }

        public virtual T? FirstOrDefaultInclude(Expression<Func<T, bool>> filter, params string[] includeProps)
        {
            var query = dbSet.AsQueryable();
            if (includeProps.Length > 0)
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }

            return query.FirstOrDefault(filter);
        }
    }
}
