
using ApiDevelop.Services.Mappers.Dtos;

namespace ApiDevelop.Services
{
    public interface IProductoService
    {

        List<ProductoDTO> GetAllProductos();
        ProductoDTO GetProductoById(int id);
        bool SaveProducto(ProductoDTO producto);
        void DeleteProducto(int id);

    }
}
