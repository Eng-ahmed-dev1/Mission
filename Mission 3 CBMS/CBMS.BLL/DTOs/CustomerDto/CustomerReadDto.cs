using CBMS.BLL.DTOs.MovieDto;
using CBMS.BLL.DTOs.TicketDto;

namespace CBMS.BLL.DTOs.CustomerDto
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public TicketReadDto Ticket { get; set; }

        public List<MovieReadDto> Movies { get; set; } = new List<MovieReadDto>();
    }
}
