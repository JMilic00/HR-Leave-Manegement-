using HR.LeaveManegement.Aplication.Contracts.Persistance;
using HR.LeaveManegement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManegementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManegementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
