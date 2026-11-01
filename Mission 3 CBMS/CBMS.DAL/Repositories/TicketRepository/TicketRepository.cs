namespace CBMS.DAL.Repositories
{
    public class TicketRepository : ITicketRepositry
    {
        private readonly ApplicationContext _context;
        public TicketRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Ticket?> GetById(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
