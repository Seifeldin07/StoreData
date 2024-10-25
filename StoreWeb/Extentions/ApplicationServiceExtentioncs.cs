using Microsoft.AspNetCore.Mvc;
using StoreRepository.Interfaces;
using StoreRepository.Repositories;
using StoreService.Services.ProductServices.Dtos;
using StoreService.Services.ProductServices;
using StoreService.HandleResponses;
using StoreService.Services.CashService;
using StoreService.Services.BasketServices.Dtos;
using StoreService.Services.BasketServices;
using StoreRepository.Basket;

namespace StoreWeb.Extentions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService,ProductServices>();
            services.AddScoped<ICashService, CashService>();
            //services.AddScoped<IBasketService, BasketServiess>();
            services.AddScoped<IBasketRepository, BasketServiess>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(BasketProfile));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                                .Where(model => model.Value?.Errors.Count() > 0)
                                                .SelectMany(model => model.Value?.Errors)
                                                .Select(error => error.ErrorMessage)
                                                .ToList();
                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }



}
