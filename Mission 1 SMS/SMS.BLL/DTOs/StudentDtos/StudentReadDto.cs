namespace SMS.BLL.DTOs
{
    public class StudentReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string LaptopModel { get; set; } = string.Empty;
        public List<TeacherReadDto> Teachers { get; set; } = new List<TeacherReadDto>();
    }
}
