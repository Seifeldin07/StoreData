using AutoMapper;
using StoreRepository.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreService.Services.BasketServices.Dtos
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasketDto, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItem>().ReverseMap();
        }

    }
}
