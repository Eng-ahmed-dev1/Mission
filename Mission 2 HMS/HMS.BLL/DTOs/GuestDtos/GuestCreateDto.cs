using System.ComponentModel.DataAnnotations;

namespace HMS.BLL.DTOs
{
    public class GuestCreateDto
    {
        [Required(ErrorMessage = "Guest name is required")]
        [MaxLength(100, ErrorMessage = "Guest name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = string.Empty;

        public RoomCreateDto? Room { get; set; }

        public List<int>? StaffIds { get; set; } = new List<int>();
    }
}
