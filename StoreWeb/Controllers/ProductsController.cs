using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreRepository.specification.ProductSpecs;
using StoreService.Services.ProductServices;
using StoreService.Services.ProductServices.Dtos;
using StoreWeb.Helper;

namespace StoreWeb.Controllers
{
   
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypesDetailsDto>>> GetAllBrands()
            => Ok(await _productService.GetAllBrandsAsync());
        [HttpGet]
        [Cash(10)]
        public async Task<ActionResult<IReadOnlyList<BrandTypesDetailsDto>>> GetAllTypes()
            => Ok(await _productService.GetAllTypesAsync());
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllproducts([FromQuery] ProductSpecification input)
            => Ok(await _productService.GetAllProductsAsync(input));
        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int? id)
            => Ok(await _productService.GetProductByAsync(id));
    }
}
