using HMS.BLL.DTOs;
using HMS.DAL;

namespace HMS.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepositorey _repo;
        public DepartmentService(IDepartmentRepositorey repo)
        {
            _repo = repo;
        }
        public async Task<int> AddAsync(DepartmentCreateDto dto)
        {
            if (dto is null)
                throw new bllException("Invalid Data");

            var Department = new Department
            {
                Description = dto.Description,
                Name = dto.Name,
            };
            _repo.Add(Department);
            await _repo.SaveChangesAsync();
            return Department.Id;
        }
    }
}
