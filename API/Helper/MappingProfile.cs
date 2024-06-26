using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using pyronet.Core.Entities;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductToDto>()
            .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}