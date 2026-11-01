using CBMS.BLL.DTOs.HallDto;

namespace CBMS.BLL.Services.HallService
{
    public interface IHallService
    {
        Task<HallReadDto> AddAsync(HallCreateDto dto);
    
    }
}
