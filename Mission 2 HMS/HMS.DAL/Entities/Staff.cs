using System.ComponentModel.DataAnnotations;

namespace HMS.DAL
{
    public class Staff
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

        public int DepartmentId { get; set; }
        public Department Department{ get; set; }


        public ICollection<Guest> Guests { get; set; } = new HashSet<Guest>();

    }
}
