using HMS.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace HMS.DAL
{
    public class GuestRepository : IGuestRepository
    {
        private readonly ApplicationContext _context;
        public GuestRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Guest guest)
        {
            _context.Guests.Add(guest);
        }

        public void Delete(Guest guest)
        {
            _context.Guests.Remove(guest);
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _context.Guests
                .Include(x => x.Room)
                .Include(x => x.Staffs)
                    .ThenInclude(s => s.Department)
                .ToListAsync();
        }

        public void Update(Guest guest)
        {
            _context.Update(guest);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Guest?> GetById(int id)
        {
            return await _context.Guests
                .Include(x => x.Room)
                .Include(x => x.Staffs)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
