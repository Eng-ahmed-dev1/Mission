using SMS.BLL.DTOs;
using SMS.DAL;

namespace SMS.BLL
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ITeacherRepository _teacherRepo;

        public StudentService(IStudentRepository studentRepo, ITeacherRepository teacherRepo)
        {
            _repo = studentRepo;
            _teacherRepo = teacherRepo;
        }

        public async Task<int> AddAsync(StudentCreateDto dto)
        {
            if (dto is null)
                throw new bllException("Invalid Data");

            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
            };

            if (!string.IsNullOrWhiteSpace(dto.LaptopModel))
            {
                student.Laptop = new Laptop
                {
                    Model = dto.LaptopModel
                };
            }

            if (dto.TeacherIds is not null && dto.TeacherIds.Any())
            {
                var teachers = await _teacherRepo.GetByIdsAsync(dto.TeacherIds);
                foreach (var teacher in teachers)
                {
                    student.Teachers.Add(teacher);
                }
            }

            _repo.Add(student);
            await _repo.SaveChangesAsync();
            return student.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                return false;

            var student = await _repo.GetById(id);
            if (student is null)
                return false;

            _repo.Delete(student);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StudentReadDto>> GetAllAsync()
        {
            var students = await _repo.GetAllAsync();

            return students.Select(x => new StudentReadDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                LaptopModel = x.Laptop?.Model ?? "No Laptop",
                Teachers = x.Teachers.Select(z => new TeacherReadDto
                {
                    Id = z.Id,
                    Name = z.Name,
                    Email = z.Email,
                    Phone = z.Phone,
                    SubjectName = z.Subject?.Name ?? "No Subject"
                }).ToList()
            });
        }

        public async Task<bool> UpdateAsync(int id, StudentCreateDto dto)
        {
            if (id <= 0 || dto is null)
                return false;

            var student = await _repo.GetById(id);
            if (student is null)
                return false;

            student.Name = dto.Name;
            student.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.LaptopModel))
            {
                if (student.Laptop is not null)
                {
                    student.Laptop.Model = dto.LaptopModel;
                }
                else
                {
                    student.Laptop = new Laptop
                    {
                        Model = dto.LaptopModel
                    };
                }
            }

            if (dto.TeacherIds is not null)
            {
                student.Teachers.Clear();
                if (dto.TeacherIds.Any())
                {
                    var teachers = await _teacherRepo.GetByIdsAsync(dto.TeacherIds);
                    foreach (var teacher in teachers)
                    {
                        student.Teachers.Add(teacher);
                    }
                }
            }

            _repo.Update(student);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}

