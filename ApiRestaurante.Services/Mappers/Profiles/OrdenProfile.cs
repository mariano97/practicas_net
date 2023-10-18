using ApiRestaurante.Data.Models;
using ApiRestaurante.Services.Mappers.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Services.Mappers.Profiles
{
    public  class OrdenProfile : Profile
    {

        public OrdenProfile()
        {
            CreateMap<Orden, OrdenDTO>();
            CreateMap<OrdenDTO, Orden>();
        }

    }
}
