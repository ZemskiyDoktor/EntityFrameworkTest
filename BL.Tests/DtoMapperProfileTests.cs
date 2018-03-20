using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            lusers[2].Name = "Ivan";
            
            context.Setup(users, lusers, c => c.Users);
            
            var user = context.Object.Users.FirstOrDefault(x => x.Name == "Ivan");
            //var user = context.Object.Users.FirstOrDefault(x => x.Name == lusers[0].Name);
            Assert.IsNotNull(user);
        }
    }

    internal static class DataTestExtentions
    {
        public static void Setup<TContext, T>(this Mock<TContext> context, Mock<DbSet<T>> dtSet, List<T> items, Expression<Func<TContext, DbSet<T>>> act) where T : class where TContext : class
        {
            var qitems = items.AsQueryable();
            dtSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(qitems.Provider);
            dtSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(qitems.Expression);
            dtSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(qitems.ElementType);
            dtSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => qitems.GetEnumerator());

            context.Setup(act).Returns(dtSet.Object);
        }
    }
}
