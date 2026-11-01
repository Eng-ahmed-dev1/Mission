namespace CBMS.BLL.DTOs.TicketDto
{
    public class TicketReadDto
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ShowTime { get; set; }

    }
}
