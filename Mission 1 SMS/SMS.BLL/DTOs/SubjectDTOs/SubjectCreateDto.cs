using System.ComponentModel.DataAnnotations;

namespace SMS.BLL.DTOs
{
    public class SubjectCreateDto
    {
        [Required(ErrorMessage = "Subject name is required")]
        [MaxLength(50, ErrorMessage = "Subject name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
