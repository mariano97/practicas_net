using ApiRestaurante.Data.Models;
using ApiRestaurante.Domain.Repositories;
using ApiRestaurante.Services.Mappers.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Services.Impl
{
    public class OrdenServiceImpl : IOrdenService
    {

        private IRepositoryAsync<Orden> _repository;
        private readonly IMapper _mapper;

        public OrdenServiceImpl(IRepositoryAsync<Orden> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrdenDTO> Actualizar(OrdenDTO ordenDTO)
        {
            if (ordenDTO == null || ordenDTO.Id == 0)
            {
                throw new ArgumentNullException(paramName: "OrdenDTO", message: "Parametro invalido");
            }
            Orden order = _mapper.Map<Orden>(ordenDTO);
            order = await _repository.Update(order);
            return _mapper.Map<OrdenDTO>(order);
        }

        public async Task<OrdenDTO> Delete(int id)
        {
            Orden orden = await _repository.DeleteById(id);
            return _mapper.Map<OrdenDTO>(orden);  
        }

        public async Task<IEnumerable<OrdenDTO>> GetAll()
        {
            IEnumerable<Orden> listaOrdens = await _repository.FindAll();
            return _mapper.Map<IEnumerable<OrdenDTO>>(listaOrdens); 
        }

        public async Task<OrdenDTO> GetById(int id)
        {
            Orden orden = await _repository.FindById(id);
            return _mapper.Map<OrdenDTO>(orden);
        }

        public async Task<OrdenDTO> Guardar(OrdenDTO ordenDTO)
        {
            if (ordenDTO == null || ordenDTO.Id != 0)
            {
                throw new ArgumentNullException(paramName: "OrdenDTO", message: "Parametro invalido");
            }
            Orden orden = _mapper.Map<Orden>(ordenDTO);
            orden = await _repository.Save(orden);
            return _mapper.Map<OrdenDTO>(orden);
        }
    }
}
