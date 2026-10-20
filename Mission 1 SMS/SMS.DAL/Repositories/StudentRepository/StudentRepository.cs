using Microsoft.EntityFrameworkCore;

namespace SMS.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _Context;
        public StudentRepository(ApplicationContext context)
        {
            _Context = context;
        }
        public void Add(Student student)
        {
            _Context.Students.Add(student);
        }

        public void Delete(Student student)
        {
            _Context.Students.Remove(student);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _Context.Students
                .Include(x => x.Laptop)
                .Include(x => x.Teachers)
                    .ThenInclude(t => t.Subject)
                .ToListAsync();
        }

        public async Task<Student?> GetById(int id)
        {
            return await _Context.Students
                .Include(x => x.Laptop)
                .Include(x => x.Teachers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync();
        }

        public void Update(Student student)
        {
            _Context.Students.Update(student);
        }
    }
}
