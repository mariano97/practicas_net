using Microsoft.AspNetCore.Mvc;
using TiendaApi.Datos;
using TiendaApi.Modelo;

namespace TiendaApi.Controllers
{

    [ApiController]
    [Route("api/productos")]
    public class ProductosController: ControllerBase
    {

        private readonly DatosProductos _datosProductos;

        public ProductosController()
        {

            _datosProductos = new DatosProductos();

        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosModelo>>> GetProductos()
        {
            List<ProductosModelo> lista = await this._datosProductos.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task InsertarProducto([FromBody] ProductosModelo producto)
        {
            await this._datosProductos.InsertarProductos(producto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, [FromBody] ProductosModelo producto)
        {
            producto.id = id;
            await this._datosProductos.ActualizarProductos(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = new ProductosModelo();
            producto.id = id;
            await this._datosProductos.EliminarProducto(producto);
            return NoContent();
        }

    }
}
