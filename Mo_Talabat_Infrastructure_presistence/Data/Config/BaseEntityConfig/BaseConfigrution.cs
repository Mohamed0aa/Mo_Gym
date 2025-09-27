using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Data.Config.BaseEntityConfig
{
    internal class BaseConfigrution<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();//put identity on id regardless type(id or guid)

            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.CreatedOn).IsRequired();
            builder.Property(E=>E.LastModifiedBy).IsRequired();
            builder.Property(e=>e.LastModifiedOn).IsRequired();
        }
    }
}
