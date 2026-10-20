using SMS.BLL.DTOs;

namespace SMS.BLL
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentReadDto>> GetAllAsync();
        Task<bool> UpdateAsync(int id, StudentCreateDto dto);
        Task<int> AddAsync(StudentCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
