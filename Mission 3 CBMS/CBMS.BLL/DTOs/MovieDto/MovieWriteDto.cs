using CBMS.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBMS.BLL.DTOs.MovieDto
{
    public class MovieWriteDto
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int Duration { get; set; }

        public int HallId { get; set; }
    }
}
