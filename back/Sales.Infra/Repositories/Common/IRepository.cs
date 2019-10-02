using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales.Domain.Entities.Common;
using Sales.Domain.Specification.Common;

namespace Sales.Infra.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<T> GetAsync(Specification<T> specification);
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        IReadOnlyList<T> Find(Specification<T> specification);



    }
}
