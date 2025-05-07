using AutoMapper;
using DomainLayer.Models.Products;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MapppingProfiles
{

    public class ProductResolver (IConfiguration configuration): IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (String.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;

            else
            {
                var Url = $"{ configuration.GetSection("Urls")["BaseUrl"]}{ source.PictureUrl}";
                return Url;
            }
        }
    }
}
