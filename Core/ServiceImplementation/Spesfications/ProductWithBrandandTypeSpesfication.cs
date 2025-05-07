using DomainLayer.Models.Products;
using Service.Spesfication;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Spesfications
{
    public class ProductWithBrandandTypeSpesfication : BaseSpesfication<Product,int>
    {

        public ProductWithBrandandTypeSpesfication(int?BrandId,int? TypeId, ProductSortingOptions sortingoptions) :
            base(p=>(!BrandId.HasValue |p.BrandId==BrandId )&&(!TypeId.HasValue | p.TypeId == TypeId))
        {

            AddInclude(p =>p.Brand);
            AddInclude(p => p.Type);

            switch(sortingoptions)
            {
                case ProductSortingOptions.NameAsc:
                    AddorderBy(p => p.Name);
                    break;


                case ProductSortingOptions.NameDesc:
                    AddorderDes(p => p.Name);
                    break;

                case ProductSortingOptions.PriceAsc:
                    AddorderBy(p => p.Price);
                    break;

                case ProductSortingOptions.PriceDesc:
                    AddorderDes(p => p.Price);
                    break;

                default:
                    break;
            }
        }

        public ProductWithBrandandTypeSpesfication(int id) : base(p=>p.Id ==id)
        {

            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }

    }
}
