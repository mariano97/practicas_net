using ApiRestaurante.Data.Models;
using ApiRestaurante.Services.Mappers.Dtos;
using AutoMapper;

namespace ApiRestaurante.Services.Mappers.Profiles
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }

    }
}
