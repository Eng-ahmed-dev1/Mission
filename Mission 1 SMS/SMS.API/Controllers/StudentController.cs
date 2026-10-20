using Microsoft.AspNetCore.Mvc;
using SMS.BLL;
using SMS.BLL.DTOs;

namespace SMS.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var studentId = await _service.AddAsync(dto);
                return Ok(new { id = studentId, message = "Student created successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetAllAsync()
        {
            try
            {
                var students = await _service.GetAllAsync();
                return Ok(students);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isUpdated = await _service.UpdateAsync(id, dto);
            if (!isUpdated)
                return NotFound($"Student with Id {id} was not found");

            return Ok(new { message = "Student updated successfully" });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted)
                return NotFound($"Student with Id {id} was not found");

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}