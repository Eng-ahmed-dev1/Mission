using CBMS.BLL.DTOs.TicketDto;
using System.ComponentModel.DataAnnotations;

namespace CBMS.BLL.DTOs.CustomerDto
{
    public class CustomerWriteDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        public int? MovieId { get; set; }
       public TicketCreateDto ?ticket {  get; set; }
    }
}
