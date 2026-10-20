using Microsoft.AspNetCore.Mvc;
using SMS.BLL;
using SMS.BLL.DTOs;

namespace SMS.API.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] SubjectCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = await _service.AddAsyncc(dto);
                return Ok(new { id, message = "Subject added successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}