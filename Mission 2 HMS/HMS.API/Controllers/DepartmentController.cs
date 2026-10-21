using HMS.BLL;
using HMS.BLL.DTOs;
using HMS.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] DepartmentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = await _departmentService.AddAsync(dto);
                return Ok(new { id, message = "Department added successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}