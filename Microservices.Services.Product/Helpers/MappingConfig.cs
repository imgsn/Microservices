using AutoMapper;
using Microservices.Services.Product.Dtos;

namespace Microservices.Services.Product.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Entities.Product, ProductDto>();
                config.CreateMap<ProductDto, Entities.Product>();
            });
        }
    }
}
