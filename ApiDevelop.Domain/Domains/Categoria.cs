using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevelop.Domain.Domains
{
    [Table("categoria")]
    public class Categoria
    {

        [Key]
        [Column("idcategoria")]
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string? Descripcion {  get; set; }


        public ICollection<Producto> Producto { get; set; }


    }
}
