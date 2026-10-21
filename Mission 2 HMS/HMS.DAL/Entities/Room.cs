using System.ComponentModel.DataAnnotations;

namespace HMS.DAL
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoomNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        public int? GuestId { get; set; }
        public Guest? Guest { get; set; }
    }
}
