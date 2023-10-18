using ApiDevelop.Domain.Domains;
using ApiDevelop.Services.Mappers.Dtos;
using AutoMapper;

namespace ApiDevelop.Services.Mappers.Profiles
{
    public class CategoriaProfile : Profile
    {

        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();
        }

    }
}
