using Application.Models;
using AutoMapper;
using Domain.Entities;

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
        }
    }
}