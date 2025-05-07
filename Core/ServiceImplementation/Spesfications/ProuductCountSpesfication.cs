using DomainLayer.Models.Products;
using Service.Spesfication;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Spesfications
{
    public class ProuductCountSpesfication:BaseSpesfication<Product,int>
    {
        public ProuductCountSpesfication(ProductQueryParam productQuery) :
           base(p => (!productQuery.BrandId.HasValue | p.BrandId == productQuery.BrandId) && (!productQuery.TypeId.HasValue | p.TypeId == productQuery.TypeId) &&
           (string.IsNullOrEmpty(productQuery.SearchValue) || p.Name.ToLower().Contains(productQuery.SearchValue.ToLower())))
        {

            
        }



    }
}
