using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestaurante.Data.Models;

public partial class Orden
{
    [Key]
    [Column("id_orden")]
    public int Id { get; set; }

    public string Plato { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
