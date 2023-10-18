using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Services.Mappers.Dtos
{
    public class OrdenDTO
    {
        public int Id { get; set; }

        public string Plato { get; set; } = null!;

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public int CustomerId { get; set; }
    }
}
