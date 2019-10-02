using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.Application.Dtos.Common;
using Sales.Domain.Entities.Common;
using Sales.Domain.Specification.Common;

namespace Sales.Application.Services.Common
{
    public interface ICrudApplication<TDto, TEntity> where TDto : BaseCrudDto where TEntity : BaseEntity
    {
        Task<TDto> AddAsync(TDto dto);
        TDto Update(TDto dto);
        void Delete(int id);
        Task<IEnumerable<TDto>> GetAllAsync();

    }

    
}
