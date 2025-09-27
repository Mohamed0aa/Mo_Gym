using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mo_Talabat_Core_Domain.Entity.Products;
using Mo_Talabat_Infrastructure_presistence.Data.Config.BaseEntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Data.Config.ProductConfig
{
    internal class ProductConfig : BaseConfigrution<Product,int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Price).IsRequired().HasColumnType("DECIMAL(9,2)");

            builder.Property(P => P.Description).IsRequired();

            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p=>p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
