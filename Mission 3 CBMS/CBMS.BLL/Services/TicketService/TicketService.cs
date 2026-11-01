using CBMS.BLL.DTOs.TicketDto;
using CBMS.DAL.Repositories;

namespace CBMS.BLL.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepositry _ticketRepository;

        public TicketService(ITicketRepositry ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketReadDto?> GetByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetById(id);
            if (ticket is null) return null;

            return new TicketReadDto
            {
                Id = ticket.Id,
                SeatNumber = ticket.SeatNumber,
                Price = ticket.Price,
                ShowTime = ticket.ShowTime
            };
        }
    }
}
