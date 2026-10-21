namespace HMS.DAL
{
    public interface IDepartmentRepositorey
    {
        void Add(Department department);
        Task<Department?> GetById(int id);
        Task<int> SaveChangesAsync();
    }
}
