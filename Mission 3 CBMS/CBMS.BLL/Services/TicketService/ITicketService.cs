using CBMS.BLL.DTOs.TicketDto;

namespace CBMS.BLL.Services.TicketService
{
    public interface ITicketService
    {
        Task<TicketReadDto?> GetByIdAsync(int id);
    }
}
