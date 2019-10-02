using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sales.Application.Dtos.Common;
using Sales.Domain.Entities.Common;
using Sales.Domain.Properties;
using Sales.Domain.Services.ValidationServices.Common;
using Sales.Infra.Context;
using Sales.Infra.Repositories.Common;

namespace Sales.Application.Services.Common
{
    public abstract class CrudApplication<TDto, TEntity> 
        : ICrudApplication<TDto, TEntity> 
        where TDto : BaseCrudDto 
        where TEntity : BaseEntity
    {
        protected readonly IConnection Connection;
        protected readonly IMapper Mapper;
        protected readonly IRepository<TEntity> Repository;
        protected readonly IValidationBeforePersist<TEntity> Validation;

        protected CrudApplication(
            IConnection connection,
            IMapper mapper,
            IRepository<TEntity> repository,
            IValidationBeforePersist<TEntity> validation)
        {
            Connection = connection;
            Mapper = mapper;
            Repository = repository;
            Validation = validation;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            if (Validation.CanPersist(entity))
            {
                await Repository.AddAsync(entity);
                Connection.Commit();
            }

            return Mapper.Map<TDto>(entity); 
        }

     
        public TDto Update(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            if (Validation.CanPersist(entity))
            {
                Repository.Update(entity);
                Connection.Commit();
            }

            return Mapper.Map<TDto>(entity);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
            Connection.Commit();
            
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TDto>>(await Repository.GetAllAsync());
        }

        
    }
}
