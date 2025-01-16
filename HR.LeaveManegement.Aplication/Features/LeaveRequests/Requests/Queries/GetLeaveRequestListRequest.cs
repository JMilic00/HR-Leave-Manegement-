using HR.LeaveManegement.Aplication.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
