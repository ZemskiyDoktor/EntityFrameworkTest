using System;
using System.Linq.Expressions;

namespace DAL.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSpecifiedBy();
    }
}