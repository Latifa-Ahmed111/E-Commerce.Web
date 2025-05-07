using DomainLayer.Models.Products;
using Service.Spesfication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Spesfications
{
    public class ProductWithBrandandTypeSpesfication : BaseSpesfication<Product,int>
    {

        public ProductWithBrandandTypeSpesfication(int?BrandId,int? TypeId):
            base(p=>(!BrandId.HasValue |p.BrandId==BrandId )&&(!TypeId.HasValue | p.TypeId == TypeId))
        {

            AddInclude(p =>p.Brand);
            AddInclude(p => p.Type);
        }

        public ProductWithBrandandTypeSpesfication(int id) : base(p=>p.Id ==id)
        {

            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }

    }
}
