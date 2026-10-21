using HMS.BLL.DTOs;

namespace HMS.BLL
{
    public interface IStaffService
    {
        Task<int> AddAsync(StaffCreateDto dto);
        Task<StaffReadDto?> GetByIdAsync(int id);

    }
}
