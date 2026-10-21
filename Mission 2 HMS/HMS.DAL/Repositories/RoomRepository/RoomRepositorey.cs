
using HMS.DAL.Data;

namespace HMS.DAL
{
    public class RoomRepositorey : IRoomRepositorey
    {
        private readonly ApplicationContext _context;
        public RoomRepositorey(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
