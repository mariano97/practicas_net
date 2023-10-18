using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductoService _productoService;

        public ProductController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        public IActionResult SaveProducto([FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null || productoDTO.Id != 0)
            {
                return BadRequest(error: "Producto no se puede guardar");
            }
            try
            {
                bool result = _productoService.SaveProducto(productoDTO);
                if (result)
                {
                    return Created(uri: "/api/producto", productoDTO);
                } else
                {
                    return BadRequest();
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ActualizarProducto([FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null || productoDTO.Id == 0)
            {
                return BadRequest(error: "Producto no se puede actualizar");
            }
            try
            {
                bool result = _productoService.SaveProducto(productoDTO);
                if (result)
                {
                    return Ok(productoDTO);
                } else
                {
                    return BadRequest();
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult GetAllProductos()
        {
            try
            {
                IList<ProductoDTO> productos = _productoService.GetAllProductos();
                return Ok(productos);

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            try
            {
                ProductoDTO producto = _productoService.GetProductoById(id);
                return Ok(producto);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id) {
            try
            {
                _productoService.DeleteProducto(id);
                return Ok(new { mensaje = "Elemento eliminado"});
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
