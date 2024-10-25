using AutoMapper;
using Microsoft.Extensions.Configuration;
using StoreData.Entities;

namespace StoreService.Services.ProductServices.Dtos
{
    public class PictureUrlResolver : IValueResolver<Product, ProductDetailsDto, string>
    {
        private readonly IConfiguration _config;

        public PictureUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductDetailsDto destination, string destMember, ResolutionContext context)
        {
            if(source.PictureUrl != null)
            {
                return $"{_config.GetSection("BaseUrl").Value}/{source.PictureUrl}";
            }
            return string.Empty ;
        }
    }
}
