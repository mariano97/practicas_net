using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevelop.Domain.Domains
{
    public class Producto
    {

        [Key]
        [Column("idproducto")]
        public int Id { get; set; }

        [Column("codigo_barra")]
        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public string Marca {  get; set; }

        [Column("id_categoria")]
        //[ForeignKey("id_categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int Precio { get; set; }

    }
}
