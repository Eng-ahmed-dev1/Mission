using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DAL
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [ForeignKey(nameof(LaptopId))]
        public int? LaptopId { get; set; }
        public Laptop? Laptop { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();

    }
}
