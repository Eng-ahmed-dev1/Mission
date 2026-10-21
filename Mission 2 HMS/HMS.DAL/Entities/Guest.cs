using System.ComponentModel.DataAnnotations;

namespace HMS.DAL
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    }
}
