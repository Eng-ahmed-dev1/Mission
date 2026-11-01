using CBMS.BLL.DTOs.MovieDto;
using CBMS.BLL.Exceptions;
using CBMS.BLL.Services.MovieService;
using Microsoft.AspNetCore.Mvc;

namespace CBMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] MovieWriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var movie = await _movieService.AddAsync(dto);
                return Ok(movie);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieReadDto>> GetByIdAsync(int id)
        {
            try
            {
                var movie = await _movieService.GetByIdAsync(id);
                if (movie == null)
                    return NotFound($"Movie with Id {id} was not found");

                return Ok(movie);
            }
            catch (bllException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
