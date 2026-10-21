using System.ComponentModel.DataAnnotations;

namespace HMS.BLL.DTOs
{
    public class StaffCreateDto
    {
        [Required(ErrorMessage = "Staff name is required")]
        [MaxLength(100, ErrorMessage = "Staff name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "A valid DepartmentId is required")]
        public int DepartmentId { get; set; }
    }
}
