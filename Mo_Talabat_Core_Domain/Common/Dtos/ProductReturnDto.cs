using Mo_Talabat_Core_Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Common.Dtos
{
    public class ProductReturnDto
    {
        public required int id {  get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? PictureUrl { get; set; }
        public required decimal Price { get; set; }

        public int? BrandId { get; set; }//forignkey
        public string? Brand { get; set; }
        public int? CategoryId { get; set; } //forignkey
        public string? Category { get; set; }
    }
}
