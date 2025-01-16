using HR.LeaveManegement.Aplication.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public  CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
