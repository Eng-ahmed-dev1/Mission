using HMS.DAL.Data;

namespace HMS.DAL
{
    public class DepartmentRepository : IDepartmentRepositorey
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }

        public async Task<Department?> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
