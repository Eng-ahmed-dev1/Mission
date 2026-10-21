using System.ComponentModel.DataAnnotations;

namespace HMS.BLL.DTOs
{
    public class RoomCreateDto
    {
        [Required(ErrorMessage = "Room number is required")]
        public string RoomNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Room type is required")]
        [MaxLength(50, ErrorMessage = "Room type cannot exceed 50 characters")]
        public string Type { get; set; } = string.Empty;
    }
}
