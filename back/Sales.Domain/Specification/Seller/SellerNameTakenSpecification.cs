using Sales.Domain.Entities;
using Sales.Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace Sales.Domain.Specification.Seller
{
    public class SellerNameTakenSpecification : Specification<Entities.Seller>
    {
        private readonly Entities.Seller _right;


        public SellerNameTakenSpecification(Entities.Seller right)
        {
            _right = right;
        }

        public override Expression<Func<Entities.Seller, bool>> ToExpression()
        {
            return seller =>
                seller.Name.ToLower(CultureInfo.InvariantCulture)
                    .Equals(_right.Name.ToLower(CultureInfo.InvariantCulture))
                && ((seller.Id != _right.Id) || (_right.Id == 0));
        }
    }
}
