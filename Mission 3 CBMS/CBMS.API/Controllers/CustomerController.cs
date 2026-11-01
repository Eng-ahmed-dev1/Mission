using CBMS.BLL.DTOs.CustomerDto;
using CBMS.BLL.Exceptions;
using CBMS.BLL.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace CBMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CustomerWriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var customer = await _service.AddAsync(dto);
                return Ok(customer);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllAsync()
        {
            try
            {
                var customers = await _service.GetAllAsync();
                return Ok(customers);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] CustomerWriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedCustomer = await _service.UpdateAsync(id, dto);
                if (updatedCustomer == null)
                    return NotFound($"Customer with Id {id} was not found");

                return Ok(updatedCustomer);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                var isDeleted = await _service.DeleteAsync(id);
                if (!isDeleted)
                    return NotFound($"Customer with Id {id} was not found");

                return Ok(new { message = "Customer deleted successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
