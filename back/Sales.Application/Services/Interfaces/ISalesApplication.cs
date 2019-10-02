using System.Collections.Generic;
using System.Threading.Tasks;
using Sales.Application.Dtos;
using Sales.Application.Dtos.Common;
using Sales.Application.Services.Common;
using Sales.Domain.Entities;
using Sales.Domain.Entities.Common;

namespace Sales.Application.Services.Interfaces
{
    public interface ISalesApplication : ICrudApplication<SalesDto, Sale> 
    {
        Task<SalesDto> GetByIdAsync(int id);

        Task<List<ComissaoDto>> GetComissionsAsync();

        Task<List<SalesDto>> SalesDay();
    }
}
