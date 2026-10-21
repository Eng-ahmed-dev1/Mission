using HMS.BLL;
using HMS.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync([FromBody] StaffCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = await _staffService.AddAsync(dto);
                return Ok(new { id, message = "Staff member added successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StaffReadDto>> GetById(int id)
        {
            try
            {
                var staff = await _staffService.GetByIdAsync(id);
                return Ok(staff);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}