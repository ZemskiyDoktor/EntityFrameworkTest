using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BL.Tests
{
    public class AutoEfMoqDataAttribute : AutoDataAttribute
    {
        public AutoEfMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture()
                    .Customize(new AutoMoqCustomization())
                    .Customize(new EntityCustomization());

                return fixture;
            })
        {
        }
    }

    public class EntityCustomization : ICustomization
    {
        #region Implementation of ICustomization

        public void Customize(IFixture fixture)
        {
            fixture.Register<DbContextOptions>(() => new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        }

        #endregion
    }
}