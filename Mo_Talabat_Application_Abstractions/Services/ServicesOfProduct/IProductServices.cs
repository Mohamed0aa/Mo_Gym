using Mo_Talabat_Core_Domain.Common.Dtos;
using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfProduct
{
    public interface IProductServices
    {
        public Task<IEnumerable<ProductReturnDto>> GetProductsAsync(SpecParam spec);
        public Task<ProductReturnDto> GetProductAsync(int id);
        public Task<IEnumerable<BrandDto>> GetBrandAsync();

        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync();


    }
}
