using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Categories, opt => opt.MapFrom(p => p.ProductCategories.Select(pc => pc.Category)));            

            CreateMap<CreateProductDto, Product>()
                .ForMember(p => p.ProductCategories, opt =>                            
                            {
                                opt.PreCondition(dto => dto.Categories != null);
                                opt.MapFrom(dto => dto.Categories.Select(catId => new ProductCategory() { CategoryId = catId }));
                            });
        }
    }
}
