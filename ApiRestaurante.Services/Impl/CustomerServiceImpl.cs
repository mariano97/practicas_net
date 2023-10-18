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
    public class CustomerServiceImpl : ICustomerService
    {

        private IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerServiceImpl(IRepositoryAsync<Customer> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CustomerDTO> Actualizar(CustomerDTO customerDTO)
        {
            if (customerDTO == null || customerDTO.Id == 0)
            {
                throw new ArgumentNullException(paramName: "CustomerDTO", message: "Parametro invalido");
            }
            Customer customer = _mapper.Map<Customer>(customerDTO);
            customer = await _repository.Update(customer);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> Delete(int id)
        {
            Customer customer = await _repository.DeleteById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            IEnumerable<Customer> listaCustomer = await _repository.FindAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(listaCustomer);
        }

        public async Task<CustomerDTO> GetById(int id)
        {
            Customer customer = await _repository.FindById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> Guardar(CustomerDTO customerDTO)
        {
            if (customerDTO == null || customerDTO.Id != 0)
            {
                throw new ArgumentNullException(paramName: "CustomerDTO", message: "Parametro invalido");
            }
            Customer customer = _mapper.Map<Customer>(customerDTO);
            customer = await _repository.Save(customer);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
