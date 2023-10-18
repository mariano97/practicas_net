using ApiDevelop.Domain.Domains;
using ApiDevelop.Services.Mappers.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevelop.Services.Mappers.Profiles
{
    public class ProductoProfile : Profile
    {

        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();
        }

    }
}
