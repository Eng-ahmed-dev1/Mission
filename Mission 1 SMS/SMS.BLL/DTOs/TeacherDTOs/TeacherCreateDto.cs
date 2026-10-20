using System.ComponentModel.DataAnnotations;

namespace SMS.BLL.DTOs
{
    public class TeacherCreateDto
    {
        [Required(ErrorMessage = "Teacher name is required")]
        [MaxLength(100, ErrorMessage = "Teacher name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required(ErrorMessage = "SubjectId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "A valid SubjectId is required")]
        public int SubjectId { get; set; }
    }
}
