using AutoMapper;
using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config
{
  public class MappingConfig
  {
    public static MapperConfiguration RegisterMaps()
    {
      var mappingconfig = new MapperConfiguration(config =>
      {
        config.CreateMap<ProductDTO, Product>();
        config.CreateMap<Product, ProductDTO>();
      });
      return mappingconfig;
    }
  }
}