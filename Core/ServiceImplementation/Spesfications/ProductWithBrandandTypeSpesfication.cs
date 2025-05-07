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

        public ProductWithBrandandTypeSpesfication():base(null)
        {

            AddInclude(p =>p.Brand);
            AddInclude(p => p.Type);
        }

       
    }
}
