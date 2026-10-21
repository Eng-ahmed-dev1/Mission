namespace HMS.BLL.DTOs
{
    public class GuestReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public RoomReadDto? Room { get; set; }
        public List<StaffReadDto> StaffMembers { get; set; } = new List<StaffReadDto>();
    }
}
