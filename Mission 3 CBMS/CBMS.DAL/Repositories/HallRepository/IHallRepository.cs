using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBMS.DAL.Repositories
{
    public interface IHallRepository
    {
        void Add(Hall hall);
        Task<Hall?> GetById(int id);

        Task<int> SaveChangesAsync();
    }
}
