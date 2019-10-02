using System;
using System.Linq.Expressions;
using Sales.Domain.Entities.Common;

namespace Sales.Domain.Specification.Common
{
    public abstract class IdEqualsToSpecification<T> : Specification<T> where T : BaseEntity
    {
        private readonly int _id;

        protected IdEqualsToSpecification(int id)
        {
            _id = id;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return entity => entity.Id == _id;
        }
    }
}
