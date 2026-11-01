namespace CBMS.DAL.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly ApplicationContext _context;
        public HallRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Hall hall)
        {
            _context.Halls.Add(hall);
        }

        public async Task<Hall?> GetById(int id)
        {
            return await _context.Halls.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
