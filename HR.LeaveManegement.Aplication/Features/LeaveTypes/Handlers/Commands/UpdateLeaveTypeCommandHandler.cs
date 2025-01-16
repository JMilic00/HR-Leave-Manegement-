using AutoMapper;
using HR.LeaveManegement.Aplication.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManegement.Aplication.Persistance.Contracts;
using HR.LeaveManegement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Features.LeaveTypes.Handlers.Commands
{
    internal class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
         
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leaveType);

            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
