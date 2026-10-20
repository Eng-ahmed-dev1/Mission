using SMS.BLL.DTOs;

namespace SMS.BLL
{
    public interface ITeacherService
    {
        Task<int> AddAsync(TeacherCreateDto dto);
        Task<TeacherReadDto> GetByIdAsync(int id);
    }
}
