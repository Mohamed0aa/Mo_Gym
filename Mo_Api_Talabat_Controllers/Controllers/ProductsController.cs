using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]

    public class ProductsController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReturnDto>>> GetProducts([FromQuery]SpecParam Spec)
        {
            var products = await serviceManager.ProductService.GetProductsAsync( Spec);
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductReturnDto>> GetProduct(int id)
        {
            var Product= await serviceManager.ProductService.GetProductAsync(id);
            return Ok(Product);
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories() { 

            var Categories = await serviceManager.ProductService.GetCategoriesAsync();
            return Ok(Categories);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {

            var Brands = await serviceManager.ProductService.GetBrandAsync();
            return Ok(Brands);
        }




    }
}
