using HMS.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace HMS.DAL
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationContext _context;
        public StaffRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Staff record)
        {
            _context.Staffs.Add(record);
        }
        public async Task<Staff?> GetById(int id)
        {
            return await _context.Staffs.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
