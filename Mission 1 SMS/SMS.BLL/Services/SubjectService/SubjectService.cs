using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SMS.BLL.DTOs;
using SMS.DAL;

namespace SMS.BLL
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repo;
        public SubjectService(ISubjectRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> AddAsyncc(SubjectCreateDto dto)
        {
            if (dto is null)
                throw new bllException("Invalid data");
            var subject = new Subject
            {
                Description = dto.Description,
                Name = dto.Name
            };
            _repo.Add(subject);
            await _repo.SaveChangeAsync();
            return subject.Id;
        }
    }
}
