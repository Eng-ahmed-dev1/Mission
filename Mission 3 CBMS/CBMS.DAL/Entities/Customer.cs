using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBMS.DAL
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [ForeignKey(nameof(TicketId))]
        public int TicketId { get; set;  }
        public Ticket Ticket { get; set; } 

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
