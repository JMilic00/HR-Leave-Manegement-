using AutoMapper;
using HR.LeaveManegement.Aplication.DTOs.LeaveType;
using HR.LeaveManegement.Aplication.Features.LeaveTypes.Requests.Querries;
using HR.LeaveManegement.Aplication.Contracts.Persistance;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}