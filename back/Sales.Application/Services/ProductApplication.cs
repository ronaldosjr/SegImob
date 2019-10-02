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
using Sales.Domain.Specification.Restaurant;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;

namespace Sales.Application.Services
{
    public class ProductApplication: CrudApplication<ProductDto, Product>,IProductApplication
    {
        private new IProductRepostitory Repository { get; }

        public ProductApplication(
            IConnection connection, 
            IMapper mapper, 
            IProductRepostitory repository, 
            IProductValidationBeforePersist validation) : base(connection, mapper, repository, validation)
        {
            Repository = repository;
        }

        public bool IsNameTaken(ProductDto dto) =>
            Repository.Find(new ProductNameTakenSpecification(Mapper.Map<Product>(dto))).Any();

        public async Task<ProductDto> GetByIdAsync(int id) =>
            Mapper.Map<ProductDto>(await Repository.GetAsync(new ProductIdEqualsToSpecification(id)));

        public bool ValidateDelete(int id) => Repository.IsInUse(id);

        public IEnumerable<ProductDto> GetByName(string name) => Mapper.Map<IEnumerable<ProductDto>>(Repository.GetByName(name));
    }
}
