using System;
using System.Collections.Generic;
using System.Text;
using Sales.Domain.Entities;
using Sales.Infra.Repositories.Common;

namespace Sales.Infra.Repositories.Interfaces
{
    public interface IProductRepostitory : IRepository<Product>
    {
        bool IsInUse(int id);
        IEnumerable<Product> GetByName(string name);
    }
}
