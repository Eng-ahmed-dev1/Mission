using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBMS.DAL
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int Duration { get; set; }
        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        [ForeignKey(nameof(HallId))]
        public int HallId { get; set; }
        public Hall Hall { get; set; }  
    }
}
