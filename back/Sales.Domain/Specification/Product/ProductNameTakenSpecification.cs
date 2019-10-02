using System;
using System.Globalization;
using System.Linq.Expressions;
using Sales.Domain.Entities;
using Sales.Domain.Specification.Common;

namespace Sales.Domain.Specification.Restaurant
{
    public class ProductNameTakenSpecification : Specification<Product>
    {
        private readonly Product _right;


        public ProductNameTakenSpecification(Product right)
        {
            _right = right;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product =>
                product.Name.ToLower(CultureInfo.InvariantCulture)
                    .Equals(_right.Name.ToLower(CultureInfo.InvariantCulture))
                && ((product.Id !=_right.Id) || (_right.Id == 0));
        }
    }
}
