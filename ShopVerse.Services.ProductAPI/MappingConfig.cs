using AutoMapper;
using ShopVerse.Services.ProductAPI.Models;
using ShopVerse.Services.ProductAPI.Models.Dto;

namespace ShopVerse.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
