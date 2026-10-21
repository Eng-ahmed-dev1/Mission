using HMS.BLL;
using HMS.BLL.DTOs;
using HMS.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestServices _guestService;

        public GuestController(IGuestServices guestService)
        {
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] GuestCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var guestId = await _guestService.Add(dto);
                return Ok(new { id = guestId, message = "Guest created successfully" });
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestReadDto>>> GetAllAsync()
        {
            try
            {
                var guests = await _guestService.GetAll();
                return Ok(guests);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateGuest(int id, [FromBody] GuestCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isUpdated = await _guestService.Update(id, dto);
            if (!isUpdated)
                return NotFound($"Guest with Id {id} was not found");

            return Ok(new { message = "Guest updated successfully" });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var isDeleted = await _guestService.Delete(id);
            if (!isDeleted)
                return NotFound($"Guest with Id {id} was not found");

            return Ok(new { message = "Guest deleted successfully" });
        }
    }
}