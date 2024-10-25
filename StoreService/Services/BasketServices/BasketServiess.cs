using AutoMapper;
using StoreRepository.Basket;
using StoreRepository.Basket.Models;
using StoreService.Services.BasketServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreService.Services.BasketServices
{
    public class BasketServiess :IBasketRepository
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketServiess(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        => await _basketRepository.DeleteBasketAsync(basketId);

        public async Task<CustomerBasketDto> GetBasketAsync(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket == null)
                return new CustomerBasketDto();
            var mappedBasket = _mapper.Map<CustomerBasketDto>(basket);
            return mappedBasket;
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto input)
        {
            if (input.Id is null)
                input.Id = GenerateRandomBasketId();

            var customerBasket = _mapper.Map<CustomerBasket>(input);

            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);

            var mappedUpdatedBasket = _mapper.Map<CustomerBasketDto>(updatedBasket);

            return mappedUpdatedBasket;
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }

        private string GenerateRandomBasketId()
        {
            Random random = new Random();
            int randomDigits = random.Next(1000, 10000);
            return $"BS-{randomDigits}";
        }

        Task<CustomerBasket> IBasketRepository.GetBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }
    }
}
