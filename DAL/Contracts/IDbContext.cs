using System.Collections.Generic;
using System.Linq;

namespace DAL.Contracts
{
    public interface IDbContext
    {
        IQueryable<T> Provide<T>() where T : class;
        IQueryable<T> Provide<T>(ISpecification<T> specification) where T : class;
        
        void Add<T>(T item) where T : class;
        void Add<T>(IEnumerable<T> items) where T : class;

        void Remove<T, TId>(TId id) where T : class;
        void Remove<T, TId>(IEnumerable<TId> id) where T : class;

        void Update<T>(T item) where T : class;
        void Update<T>(IEnumerable<T> items) where T : class;

        void Commit();
    }
}