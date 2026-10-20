using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DAL
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();


    }
}
