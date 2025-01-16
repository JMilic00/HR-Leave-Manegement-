using AutoMapper;
using HR.LeaveManegement.Aplication.Features.LeaveAllocations;
using HR.LeaveManegement.Aplication.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManegement.Aplication.Persistance.Contracts;
using HR.LeaveManegement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationnRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationnRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand Allocation, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocation>(Allocation.LeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
