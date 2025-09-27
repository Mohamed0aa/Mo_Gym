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
    internal class ProductCatrgoryconfig: BaseConfigrution<Mo_Talabat_Core_Domain.Entity.Products.ProductCatrgory, int>
    {
            public override void Configure(EntityTypeBuilder<Mo_Talabat_Core_Domain.Entity.Products.ProductCatrgory> builder)
            {
                base.Configure(builder);
                builder.Property(c => c.Name).IsRequired();
            }
    }
}
