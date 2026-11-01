using CBMS.DAL;
using System.ComponentModel.DataAnnotations;

namespace CBMS.BLL.DTOs.HallDto
{
    public class HallReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }

    }
}
