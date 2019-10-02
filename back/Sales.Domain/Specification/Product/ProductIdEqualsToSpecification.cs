using Sales.Domain.Entities;
using Sales.Domain.Specification.Common;

namespace Sales.Domain.Specification.Restaurant
{
    public class ProductIdEqualsToSpecification : IdEqualsToSpecification<Product>
    {
        public ProductIdEqualsToSpecification(int id) : base(id)
        {
        }
    }
}
