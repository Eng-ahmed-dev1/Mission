using CBMS.BLL.DTOs.HallDto;
using CBMS.BLL.Exceptions;
using CBMS.BLL.Services.HallService;
using Microsoft.AspNetCore.Mvc;

namespace CBMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IHallService _hallService;

        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] HallCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var hall = await _hallService.AddAsync(dto);
                return Ok(hall);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
