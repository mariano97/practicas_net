using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Services.Mappers.Dtos
{
    public class CustomerDTO
    {

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public string Celular { get; set; } = null!;

    }
}
