using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Common.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
