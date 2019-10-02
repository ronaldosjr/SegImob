using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sales.Application.Dtos;
using Sales.Application.Services.Common;
using Sales.Application.Services.Interfaces;
using Sales.Domain.Entities;
using Sales.Domain.Services.ValidationServices.Common;
using Sales.Domain.Services.ValidationServices.Interface;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;

namespace Sales.Application.Services
{
    public class SalesApplication : CrudApplication<SalesDto, Sale>, ISalesApplication 
    {
        public SalesApplication(IConnection connection, 
            IMapper mapper, 
            ISalesRepository repository,
            ISalesValidationBeforePersist validation) : base(connection, mapper, repository, validation)
        {
        }

        public new Task<SalesDto> AddAsync(SalesDto dto)
        {
            dto.SellerId = (dto.Seller?.Id).GetValueOrDefault();
            dto.Seller = null;
            
            foreach (var item in dto.SalesItem)
            {
                item.ProductId = (item.Product?.Id).GetValueOrDefault();
                item.Product = null;
            }
            return base.AddAsync(dto);
        }

        public async Task<SalesDto> GetByIdAsync(int id) =>
            Mapper.Map<SalesDto>(await Repository.GetAsync(id));

        public async Task<List<ComissaoDto>> GetComissionsAsync() 
        {
            return (await Repository.GetAllAsync())
            .Where(x => x.CreationDate.Date == DateTime.Now.Date).GroupBy(x => x.Seller).Select(x => new ComissaoDto
            {
                Comission = Seller.COMMISSION * x.Sum(y => y.Total),
                SellerName = x.Key.Name
            }).OrderBy(x => x.Comission).ToList();
        }

        public async Task<List<SalesDto>> SalesDay()
        {
            return Mapper.Map<List<SalesDto>>((await Repository.GetAllAsync()).Where(x => x.CreationDate.Date == DateTime.Now.Date).ToList());
        }
        

    }
}
