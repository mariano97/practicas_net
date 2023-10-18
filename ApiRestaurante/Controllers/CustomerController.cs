using ApiRestaurante.Services;
using ApiRestaurante.Services.Mappers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                CustomerDTO customer = await _customerService.Guardar(customerDTO);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                CustomerDTO customer = await _customerService.Actualizar(customerDTO);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarAllCustomers()
        {
            try
            {
                IEnumerable<CustomerDTO> customers = await _customerService.GetAll();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarCustomerById(int id)
        {
            try
            {
                CustomerDTO customer = await _customerService.GetById(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
