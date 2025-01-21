using FluentValidation;
using HR.LeaveManegement.Aplication.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.NumberOfDays)
             .GreaterThan(0).WithMessage("{PropertyName} must be greater {ComparisonValue}");

            RuleFor(p => p.Period)
             .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
             .NotNull().WithMessage("{PropertyName} must not be null.")
             .MustAsync(async (id, token) =>
             {
                 var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                 return !leaveTypeExists;
             })
            .WithMessage("{PropertyName} does not exist.");
        }
    }
}
