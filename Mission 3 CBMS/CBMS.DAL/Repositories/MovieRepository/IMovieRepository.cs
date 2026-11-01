namespace CBMS.DAL.Repositories
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        Task<Movie?> GetById(int id);
        Task<int> SaveChangesAsync();
    }
}
