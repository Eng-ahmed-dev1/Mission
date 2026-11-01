using System.ComponentModel.DataAnnotations;

namespace CBMS.BLL.DTOs.HallDto
{
    public class HallCreateDto
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
    }
}
