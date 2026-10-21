using System.ComponentModel.DataAnnotations;

namespace HMS.DAL
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string ?Description { get; set; }


        public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    }
}
