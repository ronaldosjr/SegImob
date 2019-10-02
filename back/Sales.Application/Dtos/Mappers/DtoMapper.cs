using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Dtos.Mappers
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<SalesDto, Sale>();
            CreateMap<Sale, SalesDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<SellerDto, Seller>();
            CreateMap<Seller, SellerDto>();
            CreateMap<SalesItemDto, SalesItem>();
            CreateMap<SalesItem, SalesItemDto>();

            
        }
    }
}
