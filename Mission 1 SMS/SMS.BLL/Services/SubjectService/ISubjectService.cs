using SMS.BLL.DTOs;

namespace SMS.BLL
{
    public interface ISubjectService
    {
        Task<int> AddAsyncc(SubjectCreateDto dto);
    }
}
