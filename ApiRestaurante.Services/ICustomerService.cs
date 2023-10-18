using ApiRestaurante.Services.Mappers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Services
{
    public interface ICustomerService
    {

        Task<CustomerDTO> Guardar(CustomerDTO customerDTO);
        Task<CustomerDTO> Actualizar(CustomerDTO customerDTO);
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> GetById(int id);
        Task<CustomerDTO> Delete(int id);

    }
}
