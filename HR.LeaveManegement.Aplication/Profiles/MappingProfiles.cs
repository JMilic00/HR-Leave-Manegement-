using AutoMapper;
using HR.LeaveManegement.Aplication.DTOs.LeaveAllocation;
using HR.LeaveManegement.Aplication.DTOs.LeaveRequest;
using HR.LeaveManegement.Aplication.DTOs.LeaveType;
using HR.LeaveManegement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
