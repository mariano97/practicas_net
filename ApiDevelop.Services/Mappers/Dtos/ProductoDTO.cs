
namespace ApiDevelop.Services.Mappers.Dtos
{
    public class ProductoDTO
    {

        public int Id { get; set; }
        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }

        public int Precio { get; set; }

    }
}
