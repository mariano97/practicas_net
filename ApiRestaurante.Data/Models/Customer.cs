using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestaurante.Data.Models;

public partial class Customer
{
    [Key]
    [Column("idcustomers")]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string Celular { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
