using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BL.Mapping;
using BL.Specifications;
using BLContracts.Specifications;
using DAL;

namespace BL
{
    public interface IHaveUsers
    {
        List<UserDto> All();
    }
    public class UserService : IHaveUsers
    {
        private readonly IDbContext _context;

        public UserService(IDbContext context)
        {
            _context = context;
            Mapper.Initialize( cfg => cfg.AddProfile<DtoMapperProfile>());
        }

        public List<UserDto> All()
        {
            //var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoMapperProfile>());
            return _context.Query<User>().ProjectTo<UserDto>().ToList();
            //return config.CreateMapper().Map<User, UserDto>();
        }

        public UserDto FindUserById(string id)
        {
            var specification = new FindUserByIdSpecification(Guid.Parse(id));
            var user = _context.Provide(specification);
            return Mapper.Map<UserDto>(user);
        }
    }

    public class DummySession : IDbContext
    {
        private List<User> _users;

        public DummySession()
        {
             _users = new List<User>
            {
                new User {Email = "a@a.com", Name = "first", Id = Guid.NewGuid()},
                new User {Email = "b@a.com", Name = "second", Id = Guid.NewGuid()}
            };
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return (IQueryable<T>)_users.AsQueryable();
        }

        public void AddItem<T>(T item) where T : class
        {
            throw new NotImplementedException();
        }

        public void RemoveItem<T, TId>(TId id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Find<T>(ISpecification<T> specification) where T : class
        {
            return _users.Where((Func<User, bool>)specification.IsSpecifiedBy()).FirstOrDefault() as T;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
