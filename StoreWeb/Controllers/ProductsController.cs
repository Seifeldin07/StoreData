using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreService.Services.ProductServices;
using StoreService.Services.ProductServices.Dtos;

namespace StoreWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task  <ActionResult<IReadOnlyList<BrandTypesDetailsDto>>> GetAllBrands()
            => Ok(await _productService.GetAllBrandsAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypesDetailsDto>>> GetAllTypes()
           => Ok(await _productService.GetAllTypesAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts()
           => Ok(await _productService.GetAllProductsAsync());

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int? id)
          => Ok(await _productService.GetProductByAsync(id));
    }
}
