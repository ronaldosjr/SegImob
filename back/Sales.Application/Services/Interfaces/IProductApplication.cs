using Sales.Application.Dtos;
using Sales.Application.Services.Common;
using Sales.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Application.Services.Interfaces
{
    public interface IProductApplication : ICrudApplication<ProductDto, Product> 
    {
        bool IsNameTaken(ProductDto dto);
        Task<ProductDto> GetByIdAsync(int id);
        bool ValidateDelete(int id);
        IEnumerable<ProductDto> GetByName(string name);

    }
}
