using Microsoft.EntityFrameworkCore;

namespace CBMS.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _context;
        public MovieRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public async Task<Movie?> GetById(int id)
        {
            return await _context.Movies
                .Include(m => m.Hall)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
