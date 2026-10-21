using HMS.BLL.DTOs;

namespace HMS.BLL.Services
{
    public interface IGuestServices
    {
        Task<IEnumerable<GuestReadDto>> GetAll();
        Task<bool> Update(int id, GuestCreateDto guest);
        Task<bool> Delete(int id);
        Task<int> Add(GuestCreateDto guest);
    }
}
