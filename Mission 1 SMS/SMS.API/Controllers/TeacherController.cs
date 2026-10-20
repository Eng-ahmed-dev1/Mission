using System.CodeDom.Compiler;
using Microsoft.AspNetCore.Mvc;
using SMS.BLL;
using SMS.BLL.DTOs;

namespace SMS.API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync([FromBody] TeacherCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = await _service.AddAsync(dto);
                return Ok(new { id, message = "Teacher added successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TeacherReadDto>> GetById(int id)
        {
            try
            {
                var teacher = await _service.GetByIdAsync(id);
                return Ok(teacher);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}