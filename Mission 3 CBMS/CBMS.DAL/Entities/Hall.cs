using System.ComponentModel.DataAnnotations;

namespace CBMS.DAL
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
