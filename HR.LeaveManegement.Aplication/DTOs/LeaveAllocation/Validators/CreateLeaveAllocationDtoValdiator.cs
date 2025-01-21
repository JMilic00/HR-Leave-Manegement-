using FluentValidation;
using HR.LeaveManegement.Aplication.DTOs.LeaveRequest.Validators;
using HR.LeaveManegement.Aplication.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValdiator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationDtoValdiator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));


        }
    }
}
