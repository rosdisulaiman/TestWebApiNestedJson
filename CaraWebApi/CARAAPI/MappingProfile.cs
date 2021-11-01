using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARAAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<ScanData, ScanDto>();

            CreateMap<ScanData, ScanNestedDto>();

            //CreateMap<ScanData, ScanNestedDto>()
            //    .IncludeMembers(dest => dest.Faces);
            //CreateMap<Face, ScanNestedDto>(MemberList.None);

            CreateMap<Face, FaceDto>();
            CreateMap<ScanNestedDto, ScanData>();
            CreateMap<ScanDto, ScanData>();

            CreateMap<ScanNestedDto, ScanData>();

            CreateMap<FaceForCreationDto, Face>();

           

            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

            CreateMap<CompanyForUpdateDto, Company>();

            CreateMap<UserForRegistrationDto, User>();
        }

    }
}
