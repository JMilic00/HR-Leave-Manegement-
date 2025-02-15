﻿using FluentValidation;
using HR.LeaveManegement.Aplication.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.StartDate)
             .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
             .LessThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

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
