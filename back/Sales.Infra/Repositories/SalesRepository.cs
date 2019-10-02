using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Specification.Common;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;

namespace Sales.Infra.Repositories
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
        public SalesRepository(IConnection connection) : base(connection)
        {
        }

        public new Task<List<Sale>> GetAllAsync() => Query().Include(i => i.SalesItem).Include(i => i.Seller).ToListAsync();

        public new async Task AddAsync(Sale entity)
        {            
            await base.AddAsync(entity);
        }

        public Sale Get(Specification<Sale> specification) => 
            Query().Include(d => d.SalesItem).FirstOrDefault(specification.ToExpression().Compile());
        
    }
}
