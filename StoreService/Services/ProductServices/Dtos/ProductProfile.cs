﻿using AutoMapper;
using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace StoreService.Services.ProductServices.Dtos
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailsDto>(0)
                .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.Type.Name));

            CreateMap<ProductBrand, BrandTypesDetailsDto>();
            CreateMap<ProductType, BrandTypesDetailsDto>();



        }

    }
}