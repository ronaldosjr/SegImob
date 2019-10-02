using Sales.Domain.Specification.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Specification.Seller
{
    public class SellerIdEqualsToSpecification : IdEqualsToSpecification<Entities.Seller>
    {
        public SellerIdEqualsToSpecification(int id) : base(id)
        {
        }
    }
}
