using CBMS.BLL.DTOs.MovieDto;
using CBMS.BLL.Exceptions;
using CBMS.DAL;
using CBMS.DAL.Repositories;

namespace CBMS.BLL.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IHallRepository _hallRepository;

        public MovieService(IMovieRepository movieRepository, IHallRepository hallRepository)
        {
            _movieRepository = movieRepository;
            _hallRepository = hallRepository;
        }

        public async Task<MovieReadDto> AddAsync(MovieWriteDto dto)
        {
            if (dto is null)
                throw new bllException("Movie data is required.");

            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new bllException("Movie title is required.");

            if (dto.Duration <= 0)
                throw new bllException("Movie duration must be greater than zero.");

            var hall = await _hallRepository.GetById(dto.HallId);
            if (hall is null)
                throw new bllException($"Hall with ID {dto.HallId} does not exist.");

            var movie = new Movie
            {
                Title = dto.Title.Trim(),
                Duration = dto.Duration,
                HallId = dto.HallId,
                Hall = hall
            };

            _movieRepository.Add(movie);
            await _movieRepository.SaveChangesAsync();

            return new MovieReadDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                HallName = hall.Name
            };
        }

        public async Task<MovieReadDto?> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie is null) return null;

            return new MovieReadDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                HallName = movie.Hall?.Name ?? string.Empty
            };
        }
    }
}
