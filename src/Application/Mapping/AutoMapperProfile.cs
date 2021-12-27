using Application.Models;
using AutoMapper;
using Domain.Entities;
using WebUI.Models;

namespace Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InsertCategoryModel, Category>()
                .ReverseMap();

            CreateMap<InsertProductModel, Product>()
                .ForMember(x=>x.ProductCategories,
                    x=>x.Ignore());
            CreateMap<Product, InsertProductModel>();

            CreateMap<EditProductModel, Product>()
                .ForMember(x=>x.ProductCategories,
                    x=>x.Ignore())
                .ReverseMap();

            CreateMap<RegisterModel, Customer>()
                .ForMember(x=>x.PasswordHash,x=>x.MapFrom(a=>a.Fjalekalimi))
                .ReverseMap();
        }
    }
}