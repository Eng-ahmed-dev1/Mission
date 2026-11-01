using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBMS.DAL
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SeatNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2")]
        public decimal Price { get; set; }
        [Required]
        public DateTime ShowTime { get; set; }

        public Customer Customer { get; set; }
    }
}
