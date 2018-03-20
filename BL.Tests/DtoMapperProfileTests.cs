using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.NUnit3;
using AutoMapper;
using BL.Mapping;
using BL.Specifications;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
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

        [Test, AutoEfMoqData]
        public void TestGetAll([Frozen]Mock<DbSet<User>> users, [Frozen]Mock<LibraryContext> context, List<User> lusers)
        {
            var qusers = lusers.AsQueryable();
            users.As<IQueryable<User>>().Setup(m => m.Provider).Returns(qusers.Provider);
            users.As<IQueryable<User>>().Setup(m => m.Expression).Returns(qusers.Expression);
            users.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(qusers.ElementType);
            users.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => qusers.GetEnumerator());

            context.Setup(c => c.Users).Returns(users.Object);

            var user = context.Object.Users.FirstOrDefault(x => x.Name == lusers[0].Name);
        }
    }
}
