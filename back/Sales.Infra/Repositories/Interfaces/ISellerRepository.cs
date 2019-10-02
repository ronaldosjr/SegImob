using Sales.Domain.Entities;
using Sales.Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infra.Repositories.Interfaces
{
    public interface ISellerRepository : IRepository<Seller>
    {
        bool IsInUse(int id);

        IEnumerable<Seller> GetByName(string name);
    }
}
