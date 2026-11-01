using Microsoft.EntityFrameworkCore;

namespace CBMS.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;
        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(x => x.Ticket)
                .Include(x => x.Movies)
                    .ThenInclude(m => m.Hall)
                .ToListAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await _context.Customers
                .Include(x => x.Ticket)
                .Include(x => x.Movies)
                    .ThenInclude(m => m.Hall)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
