using DomainLayer.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data.Configrations
{
    public class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.ProductType).WithMany(B => B.Products).HasForeignKey(B => B.TypeId);
            builder.HasOne(p => p.ProductBrand).WithMany(B => B.Products).HasForeignKey(B => B.BrandId);

            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");

        }

    }
}
