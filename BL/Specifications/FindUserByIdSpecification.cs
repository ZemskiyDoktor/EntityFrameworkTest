﻿using System;
using System.Linq.Expressions;
using DAL;
using DAL.Contracts;

namespace BL.Specifications
{
    public class FindUserByIdSpecification : ISpecification<User>
    {
        private readonly Guid _id;

        public FindUserByIdSpecification(Guid id)
        {
            _id = id;
        }

        Expression<Func<User, bool>> ISpecification<User>.IsSpecifiedBy()
        {
            return user => user.Id == _id;
        }
    }
}