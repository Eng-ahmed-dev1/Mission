using System.ComponentModel.DataAnnotations;

namespace SMS.BLL.DTOs
{
    public class LaptopCreateDto
    {
        [Required(ErrorMessage = "Laptop model is required")]
        [MaxLength(100, ErrorMessage = "Laptop model cannot exceed 100 characters")]
        public string Model { get; set; } = string.Empty;
    }
}
