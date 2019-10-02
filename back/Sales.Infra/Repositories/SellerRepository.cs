using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Infra.Repositories
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(IConnection connection) : base(connection)
        {
        }

        public IEnumerable<Seller> GetByName(string name) => Query().Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

        public bool IsInUse(int id) => Query().Include(x => x.Sales).Any(x => x.Sales.Any() && x.Id == id);
    }
}
