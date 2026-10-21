using HMS.BLL.DTOs;

namespace HMS.BLL.Services
{
    public interface IDepartmentService
    {
        Task<int> AddAsync(DepartmentCreateDto dto);
    }
}
