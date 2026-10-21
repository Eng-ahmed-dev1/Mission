using HMS.BLL.DTOs;
using HMS.DAL;

namespace HMS.BLL
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repo;
        private readonly IDepartmentRepositorey _departmentRepositorey;
        public StaffService(IStaffRepository repo, IDepartmentRepositorey reps)
        {
            _repo = repo;
            _departmentRepositorey = reps;
        }
        public async Task<int> AddAsync(StaffCreateDto dto)
        {
            if (dto.DepartmentId <= 0)
                throw new bllException("Invalid department  id");

            var department = await _departmentRepositorey.GetById(dto.DepartmentId);
            if (department is null)
                throw new bllException("This dpartment is not found ");

            var staff = new Staff
            {
                DepartmentId = dto.DepartmentId,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
            };
            _repo.Add(staff);
            await _repo.SaveChangesAsync();
            return staff.Id;
        }

        public async Task<StaffReadDto?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new bllException("invalid id");

            var staff = await _repo.GetById(id);
            if (staff is null)
                throw new bllException("This is staff is not found");

            return new StaffReadDto
            {
                Id = staff.Id,
                DepartmentName = staff.Department.Name,
                Email = staff.Email,
                Name = staff.Name,
                Phone = staff.Phone,
                DepartmentId = staff.Department.Id
            };
        }
    }
}
