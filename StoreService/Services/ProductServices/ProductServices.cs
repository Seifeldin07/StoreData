using AutoMapper;
using StoreData.Entities;
using StoreRepository.Interfaces;
using StoreService.Services.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreService.Services.ProductServices
{
    public class ProductServices : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypesDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNOTrackingAsync();


            var mappedBrands = _mapper.Map< IReadOnlyList<BrandTypesDetailsDto>>(brands);
            return mappedBrands;

            //IReadOnlyList<BrandTypesDetailsDto> mappedBrands = brands.Select(x => new BrandTypesDetailsDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedAt = x.createdAt
            //}).ToList();

            //return mappedBrands;

        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsNOTrackingAsync();

            var mappedProduct =_mapper.Map <IReadOnlyList< ProductDetailsDto >>(products);

            //var mappedProducts = products.Select(x => new ProductDetailsDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    PictureUrl = x.PictureUrl,
            //    Price = x.ProductPrice,
            //    CreatedAt = x.createdAt,
            //    BrandName = x.Brand.Name,
            //    TypeName = x.Type.Name,
            //}).ToList();

            return mappedProduct;


        }


        public async Task<IReadOnlyList<BrandTypesDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsNOTrackingAsync();

            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypesDetailsDto>>(types);
            //var mappedtypes = types.Select(x => new BrandTypesDetailsDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedAt = x.createdAt
            //}).ToList();

            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("Id is null");

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(productId.Value);

            if (product is null)
                throw new Exception("product Not Found ");

            var mappedProduct = _mapper.Map<ProductDetailsDto>(product);
            //var mappedProduct = new ProductDetailsDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    CreatedAt = product.createdAt,
            //    Price = product.ProductPrice,
            //    PictureUrl = product.PictureUrl,
            //    BrandName = product.Brand.Name,
            //    TypeName = product.Type.Name
            //};

            return mappedProduct;

        }
    }
}
