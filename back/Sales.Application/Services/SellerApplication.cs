using AutoMapper;
using Sales.Application.Dtos;
using Sales.Application.Services.Common;
using Sales.Application.Services.Interfaces;
using Sales.Domain.Entities;
using Sales.Domain.Services.ValidationServices;
using Sales.Domain.Services.ValidationServices.Interface;
using Sales.Domain.Specification.Seller;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Services
{
    public class SellerApplication : CrudApplication<SellerDto, Seller>, ISellerApplication
    {
        private new ISellerRepository Repository { get; }

        public SellerApplication(
            IConnection connection,
            IMapper mapper,
            ISellerRepository repository,
            ISellerValidationBeforePersist validation) : base(connection, mapper, repository, validation)
        {
            Repository = repository;
        }

        public bool IsNameTaken(SellerDto dto) =>
            Repository.Find(new SellerNameTakenSpecification(Mapper.Map<Seller>(dto))).Any();

        public async Task<SellerDto> GetByIdAsync(int id) =>
            Mapper.Map<SellerDto>(await Repository.GetAsync(new SellerIdEqualsToSpecification(id)));

        public bool ValidateDelete(int id) => Repository.IsInUse(id);

        public IEnumerable<SellerDto> GetByName(string name) => Mapper.Map<IEnumerable<SellerDto>>(Repository.GetByName(name));
    }
}
