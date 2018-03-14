using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLContracts.Specifications;
using DAL;

namespace BL.Specifications
{
    public class FindUserByIdSpecification : ISpecification<User>
    {
        private readonly Guid _id;

        public FindUserByIdSpecification(Guid id)
        {
            _id = id;
        }

        public Func<User, bool> IsSpecifiedBy()
        {
            return user => user.Id == _id;
        }
    }

    public class FindUserByEmailSpecification : ISpecification<User>
    {
        private string _email;

        public FindUserByEmailSpecification(string email)
        {
            _email = email;
        }

        public Func<User, bool> IsSpecifiedBy()
        {
            return user => user.Email == _email;
        }
    }
}