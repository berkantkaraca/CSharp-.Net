using _43_API_EntityFramework.Models;
using _43_API_EntityFramework.Models.DTOs;
using AutoMapper;

namespace _43_API_EntityFramework.AutoMappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //CreateMap<Product, ProductCreateDTO>(); //isimlerden eşleştirme yapar. İsimler farklı olsaydı yönlendirme yapmak lazım
            //CreateMap<ProductCreateDTO, Product>();
            //CreateMap<Product, ProductCreateDTO>().ReverseMap(); //yukarıdaki satırı reversemap ile tek satırda yazdık
            CreateMap<Product, ProductReadDTO>()
                .ForMember(d => d.CategoryName, m => m.MapFrom(s => s.Category.Name))
                .ForMember(d => d.ETag, m => m.MapFrom(s => Convert.ToBase64String(s.RowVersion)));

            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();

            CreateMap<ProductPatchDTO, Product>()
                .ForAllMembers(opt => opt.Condition((src, _, srcMember) => srcMember is not null));
        }
    }
}
