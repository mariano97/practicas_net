using ApiRestaurante.Services.Mappers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Services
{
    public interface IOrdenService
    {
        Task<OrdenDTO> Guardar(OrdenDTO ordernDTO);
        Task<OrdenDTO> Actualizar(OrdenDTO ordernDTO);
        Task<IEnumerable<OrdenDTO>> GetAll();
        Task<OrdenDTO> GetById(int id);
        Task<OrdenDTO> Delete(int id);

    }
}
