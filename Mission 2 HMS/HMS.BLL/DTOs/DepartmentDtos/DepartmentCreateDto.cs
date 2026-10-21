using System.ComponentModel.DataAnnotations;

namespace HMS.BLL.DTOs
{
    public class DepartmentCreateDto
    {
        [Required(ErrorMessage = "Department name is required")]
        [MaxLength(50, ErrorMessage = "Department name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
