using System;
using System.Linq.Expressions;
using DAL;
using DAL.Contracts;

namespace BL.Specifications
{
    public class FindUserByEmailSpecification : ISpecification<User>
    {
        private string _email;

        public FindUserByEmailSpecification(string email)
        {
            _email = email;
        }

        Expression<Func<User, bool>> ISpecification<User>.IsSpecifiedBy()
        {
            return user => user.Email == _email;
        }
    }
}