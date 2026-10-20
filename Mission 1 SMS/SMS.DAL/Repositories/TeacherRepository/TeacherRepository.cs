using Microsoft.EntityFrameworkCore;

namespace SMS.DAL
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationContext _context;
        public TeacherRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        public async Task<Teacher?> GetById(int id)
        {
            return await _context.Teachers.Include(x => x.Subject).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Teacher>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Teachers.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
