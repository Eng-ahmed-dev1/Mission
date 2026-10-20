using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DAL{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        Task<Teacher?> GetById(int id);
        Task<List<Teacher>> GetByIdsAsync(IEnumerable<int> ids);
        Task<int> SaveChangesAsync();
    }
}
