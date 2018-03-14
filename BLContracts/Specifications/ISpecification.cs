using System;

namespace BLContracts.Specifications
{
    public interface ISpecification<in T>
    {
        Func<T, bool> IsSpecifiedBy();
    }
}