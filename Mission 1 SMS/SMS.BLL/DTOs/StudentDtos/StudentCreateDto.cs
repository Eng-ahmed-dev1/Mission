using System.ComponentModel.DataAnnotations;

namespace SMS.BLL.DTOs
{
    public class StudentCreateDto
    {
        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(100, ErrorMessage = "Student name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? LaptopModel { get; set; }

        public List<int>? TeacherIds { get; set; }
    }
}
