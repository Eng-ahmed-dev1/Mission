using SMS.BLL.DTOs;
using SMS.DAL;

namespace SMS.BLL
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repo;
        public TeacherService(ITeacherRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> AddAsync(TeacherCreateDto dto)
        {
            if (dto is null)
                throw new bllException("Invalid data");
            if (dto.SubjectId <= 0)
                throw new bllException("Invalid Subject Id ");

            var teacher = new Teacher
            {
                Email = dto.Email,
                Name = dto.Name,
                SubjectId = dto.SubjectId,
                Phone = dto.Phone
            };
            _repo.Add(teacher);
            await _repo.SaveChangesAsync();
            return teacher.Id;
        }

        public async Task<TeacherReadDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new bllException("Invalid Id ");
            var teacher = await _repo.GetById(id);
            if (teacher is null)
                throw new bllException("This teacher is not found ");

            return new TeacherReadDto
            {
                Email = teacher.Email,
                Id = teacher.Id,
                Name = teacher.Name,
                Phone = teacher.Phone,
                SubjectName = teacher.Subject.Name

            };
        }
    }
}
