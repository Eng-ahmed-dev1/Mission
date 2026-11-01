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
    public class TicketReadDto
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ShowTime { get; set; }

    }
}
