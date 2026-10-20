using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DAL
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;
    }
}
