namespace SMS.DAL
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        void Update(Student student);
        void Add(Student student);
        void Delete(Student student);
        Task<Student?> GetById (int id);    
        Task<int> SaveChangesAsync();
    }
}
