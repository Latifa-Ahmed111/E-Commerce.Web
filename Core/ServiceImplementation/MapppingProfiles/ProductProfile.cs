using AutoMapper;
using DomainLayer.Models.Products;
using Microsoft.Extensions.Options;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MapppingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(Dist => Dist.BrandName, options => options.MapFrom(src => src.Brand.Name))

           .ForMember(Dist => Dist.TypeName, options => options.MapFrom(src => src.Type.Name))
           .ForMember(Dist=>Dist.PictureUrl,options=> options.MapFrom<ProductResolver>());

            CreateMap<ProductBrand, BrandDto>();

            CreateMap<ProductType, TypeDto>();
        }


    }
}
