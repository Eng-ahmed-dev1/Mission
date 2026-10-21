using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public interface IStaffRepository
    {
        void Add(Staff record);

        Task<Staff?> GetById(int id);

        Task<int> SaveChangesAsync();

    }
}
