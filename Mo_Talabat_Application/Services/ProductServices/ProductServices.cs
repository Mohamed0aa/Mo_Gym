using AutoMapper;
using Mo_Talabat_Core_Domain.Common.Dtos;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Core_Domain.Entity.Products;
using Mo_Talabat_Core_Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfProduct;
using Share;

namespace Mo_Talabat_Core_Application.Services.ProductServices
{
    internal class ProductServices(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductServices
    {
        public async Task<IEnumerable<ProductReturnDto>> GetProductsAsync(SpecParam specParam)
        {
            ProductSpecification spec = new(specParam);
            var product = await _unitOfWork.GetRepo<Product, int>().GetAllAsync(spec);
            var ProductDto = _mapper.Map<IEnumerable<ProductReturnDto>>(product);
            return ProductDto;
        }
        public async Task<ProductReturnDto> GetProductAsync(int id)
        {
            ProductSpecification spec = new(id);
            var product = await _unitOfWork.GetRepo<Product, int>().GetAsync(spec);
            var productReturn = _mapper.Map<ProductReturnDto>(product);

            return productReturn;
        }

        public async Task<IEnumerable<BrandDto>> GetBrandAsync()
        {
            var brands = await _unitOfWork.GetRepo<ProductBrand, int>().GetAllAsync();
            var brandReturn = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandReturn;
        }


        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var catrgories = await _unitOfWork.GetRepo<ProductCatrgory, int>().GetAllAsync();
            var CategoryReturn = _mapper.Map<IEnumerable<CategoryDto>>(catrgories);
            return CategoryReturn;
        }
    }
}
