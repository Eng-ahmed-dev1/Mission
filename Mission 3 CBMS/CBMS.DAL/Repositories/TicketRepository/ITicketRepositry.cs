using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBMS.DAL.Repositories
{
    public interface ITicketRepositry
    {
        Task<Ticket?> GetById(int id);
        Task<int> SaveChangesAsync();
    }
}
