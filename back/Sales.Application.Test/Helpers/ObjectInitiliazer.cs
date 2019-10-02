using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Application.Dtos.Mappers;
using Sales.Application.Services;
using Sales.Application.Services.Interfaces;
using Sales.Domain.Services.ValidationServices;
using Sales.Infra.Context;
using Sales.Infra.Repositories;

namespace Sales.Application.Test.Helpers
{
    public static class ObjectInitiliazer
    {
      
        public static (ISalesApplication, IProductApplication) CreateDishApplication()
        {
            var (connection, mapper) = LoadDependencies();
            var repository = new SalesRepository(connection);
            var repositoryRestaurant = new ProductRepository(connection);

            return
                (new SalesApplication(connection, mapper, repository, new SalesValidationBeforePersist()),
                    new ProductApplication(connection, mapper, repositoryRestaurant,
                        new ProductValidationBeforePersist(repositoryRestaurant)));
        }


        public static IProductApplication CreateProductApplication()
        {
            var (connection, mapper) = LoadDependencies();
            var repository = new ProductRepository(connection);

            return new ProductApplication(connection, mapper, repository, new ProductValidationBeforePersist(repository));
        }


        private static (Connection,IMapper) LoadDependencies()
        {
            var builder = new DbContextOptionsBuilder<SalesContext>().UseInMemoryDatabase("sales")
                .Options;
            var context = new SalesContext(builder);
            var connection = new Connection(context);

            var mapperConfig = new MapperConfiguration(map => { map.AddProfile<DtoMapper>(); });
            var mapper = mapperConfig.CreateMapper();

            return (connection, mapper);
        }
    }

}
