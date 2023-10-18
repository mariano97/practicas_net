using ApiRestaurante.Services;
using ApiRestaurante.Services.Mappers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {

        private IOrdenService _ordenService;

        public OrdenController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpPost]
        public async Task<IActionResult> GuardarOrden([FromBody] OrdenDTO ordenDTO)
        {
            try
            {
                OrdenDTO orden = await _ordenService.Guardar(ordenDTO);
                return Ok(orden);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarOrden([FromBody] OrdenDTO ordenDTO)
        {
            try
            {
                OrdenDTO orden = await _ordenService.Actualizar(ordenDTO);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarAll()
        {
            try
            {
                IEnumerable<OrdenDTO> ordenes = await _ordenService.GetAll();
                return Ok(ordenes);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarById(int id)
        {
            try
            {
                OrdenDTO ordenes = await _ordenService.GetById(id);
                return Ok(ordenes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            try
            {
                await _ordenService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
