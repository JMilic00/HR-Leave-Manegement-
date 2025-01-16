using HR.LeaveManegement.Aplication.DTOs.LeaveAllocation;
using HR.LeaveManegement.Aplication.DTOs.LeaveRequest;
using HR.LeaveManegement.Aplication.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}
