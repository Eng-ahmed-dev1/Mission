using System.ComponentModel.DataAnnotations;

namespace CBMS.BLL.DTOs.TicketDto
{
    public class TicketCreateDto
    {
        public string SeatNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
