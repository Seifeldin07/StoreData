using StoreService.Services.BasketServices.Dtos;

namespace StoreWeb.Controllers
{
    public interface IPaymentService
    {
        Task<object?> CreateOrUpdatePaymentIntent(CustomerBasketDto input);
        Task UpdatePaymentOrderSucceed(object id);
    }
}