using AutoMapper;
using System.Linq;
using HR.LeaveManegement.Aplication.DTOs.LeaveRequest.Validators;
using HR.LeaveManegement.Aplication.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManegement.Aplication.Contracts.Persistance;
using HR.LeaveManegement.Aplication.Responses;
using HR.LeaveManegement.Domain;
using MediatR;
using HR.LeaveManegement.Aplication.Contracts.Infrastructure;
using HR.LeaveManegement.Aplication.Models;

namespace HR.LeaveManegement.Aplication.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestnRepository, 
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestnRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
         
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "jakovmilic5@gmail.com",
                Body = $"Youzr leave for {request.LeaveRequestDto.StartDate:D} to{request.LeaveRequestDto.EndDate:D} has been successful",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
            }

            return response;
        }
    }
}
