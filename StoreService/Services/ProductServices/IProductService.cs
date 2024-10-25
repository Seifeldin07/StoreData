using StoreRepository.specification.ProductSpecs;
using StoreService.Helper;
using StoreService.Services.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreService.Services.ProductServices
{
    public interface IProductService
    {
        Task<ProductDetailsDto> GetProductByAsync(int? productId);

        Task<PagenatiedResultDto<ProductDetailsDto>> GetAllProductsAsync(ProductSpecification specs);

        Task<IReadOnlyList<BrandTypesDetailsDto>> GetAllBrandsAsync();


        Task<IReadOnlyList<BrandTypesDetailsDto>> GetAllTypesAsync();







    }

}
