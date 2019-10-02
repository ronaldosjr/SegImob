using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepostitory
    {
        public ProductRepository(IConnection connection) : base(connection)
        {

        }

        public IEnumerable<Product> GetByName(string name) => Query().Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

        public bool IsInUse(int id) => Query().Include(x => x.SalesItem).Any(x => x.SalesItem.Any() && x.Id == id);
    }
}
