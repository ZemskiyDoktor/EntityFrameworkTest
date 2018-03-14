using System.Collections.Generic;
using System.Linq;
using DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public abstract class BaseContext : DbContext, IDbContext
    {
        protected BaseContext(DbContextOptions options) : base(options)
        {
        }

        public IQueryable<T> Provide<T>() where T : class
        {
            return Set<T>();
        }

        public IQueryable<T> Provide<T>(ISpecification<T> specification) where T : class
        {
            return Set<T>().Where(specification.IsSpecifiedBy());
        }

        void IDbContext.Add<T>(T item)
        {
            Add(item);
        }

        public void Add<T>(IEnumerable<T> items) where T : class
        {
            throw new System.NotImplementedException();
        }

        void IDbContext.Remove<T, TId>(TId id)
        {
            T entity = Set<T>().Find(id);
            Remove(entity);
        }

        void IDbContext.Remove<T, TId>(IEnumerable<TId> id)
        {
            T entity = Set<T>().Find(id);
            Remove(entity);
        }

        void IDbContext.Update<T>(T item)
        {
            Set<T>();
        }

        public void Update<T>(IEnumerable<T> items) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}