using CBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBMS.BLL.DTOs.TicketDto
{
    public class TicketCreateDto
    {
        [Required]
        public string SeatNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2")]
        public decimal Price { get; set; }
        [Required]
        public DateTime ShowTime { get; set; }

    }
}
