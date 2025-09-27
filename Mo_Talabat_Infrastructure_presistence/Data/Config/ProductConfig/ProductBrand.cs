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
    internal class ProductBrandConfig: BaseConfigrution<ProductBrand,int>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);
            builder.Property(b=>b.Name).IsRequired();
        }
    }
}
