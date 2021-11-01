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

            CreateMap<ScanData, ScanDto>()
                .IncludeMembers( c => c.Faces);
            CreateMap<Face, ScanDto>(MemberList.None);

            CreateMap<ScanData, ScanForCreationDto>();

            //CreateMap<ScanData, ScanNestedDto>()
            //    .IncludeMembers(dest => dest.Faces);
            //CreateMap<Face, ScanNestedDto>(MemberList.None);
            
            //Mapper.CreateMap<DomainClass, Child>();
            //Mapper.CreateMap<DomainClass, Parent>()
            //      .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            //      .ForMember(d => d.A, opt => opt.MapFrom(s => s.A))
            //      .ForMember(d => d.Child,
            //                 opt => opt.MapFrom(s => Mapper.Map<DomainClass, Child>(s)));

            CreateMap<Face, FaceDto>();
            CreateMap<ScanForCreationDto, ScanData>();
            CreateMap<ScanDto, ScanData>();

            CreateMap<ScanForCreationDto, ScanData>();

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
