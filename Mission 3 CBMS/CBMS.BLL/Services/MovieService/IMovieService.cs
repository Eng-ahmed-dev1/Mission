using CBMS.BLL.DTOs.MovieDto;

namespace CBMS.BLL.Services.MovieService
{
    public interface IMovieService
    {
        Task<MovieReadDto> AddAsync(MovieWriteDto dto);
        Task<MovieReadDto?> GetByIdAsync(int id);
    }
}
