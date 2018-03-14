using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BL.Mapping;
using BL.Specifications;
using DAL;
using DAL.Contracts;

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
            return _context.Provide<User>().ProjectTo<UserDto>().ToList();
            //return config.CreateMapper().Map<User, UserDto>();
        }

        public UserDto FindUserById(string id)
        {
            var specification = new FindUserByIdSpecification(Guid.Parse(id));
            var user = _context.Provide(specification).First();
            return Mapper.Map<UserDto>(user);
        }
    }
}
