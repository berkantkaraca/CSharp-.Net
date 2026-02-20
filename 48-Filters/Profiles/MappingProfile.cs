using AutoMapper;
using _48_Filters.Models.Product;

namespace _48_Filters.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductSaveDto, Product>();
        }
    }
}
