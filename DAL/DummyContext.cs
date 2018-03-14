using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL;
using DAL.Contracts;

namespace BL
{
    //public class DummyContext : IDbContext
    //{
    //    private List<User> _users;

    //    public DummyContext()
    //    {
    //        _users = new List<User>
    //        {
    //            new User {Email = "a@a.com", Name = "first", Id = Guid.NewGuid()},
    //            new User {Email = "b@a.com", Name = "second", Id = Guid.NewGuid()}
    //        };
    //    }

    //    public IQueryable<T> Query<T>() where T : class
    //    {
    //        return (IQueryable<T>)_users.AsQueryable();
    //    }

    //    public void AddItem<T>(T item) where T : class
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void RemoveItem<T, TId>(TId id) where T : class
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public T Find<T>(ISpecification<T> specification) where T : class
    //    {
    //        return _users.Where((Expression<Func<User, bool>>)specification.IsSpecifiedBy()).FirstOrDefault() as T;
    //    }

    //    public void Commit()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}