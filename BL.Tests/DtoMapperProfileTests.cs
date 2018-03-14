using AutoMapper;
using BL.Mapping;
using BL.Specifications;
using NUnit.Framework;

namespace BL.Tests
{
    [TestFixture]
    internal class DtoMapperProfileTests
    {
        [Test]
        public void TestMapping()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoMapperProfile>());

            config.AssertConfigurationIsValid();
        }

        //[Test]
        //public void TestGetAll()
        //{
        //    var session = new DummySession();
        //    var userService = new UserService(session);

        //    var users = userService.All();
        //}

        //[Test]
        //public void TestFindById()
        //{
        //    var session = new DummySession();
        //    var userService = new UserService(session);

        //    var user = userService.FindUserById(2);
        //}
    }
}
