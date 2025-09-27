using Mo_Talabat_Core_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Entity.Products
{
    public class ProductCatrgory:BaseEntity<int>
    {
        public required string Name { get; set; }

    }
}
