using Sales.Application.Dtos;
using Sales.Application.Services.Common;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Services.Interfaces
{
    public interface ISellerApplication : ICrudApplication<SellerDto, Seller>
    {
        bool IsNameTaken(SellerDto dto);
        Task<SellerDto> GetByIdAsync(int id);
        bool ValidateDelete(int id);
        IEnumerable<SellerDto> GetByName(string name);

    }
}
