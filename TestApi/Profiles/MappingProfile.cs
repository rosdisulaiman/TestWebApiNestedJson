using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestApi.Models;
using TestApi.Models.DataTransferObjects;

namespace TestApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
     

            CreateMap<ScanData, ScanDataDTO>()
                .ForMember(c => c.ScanLocation,
                        opt => opt.MapFrom(x => string.Join(' ', x.devid, x.devname)));
            CreateMap<ScanDataDTO, ScanData>();
            CreateMap<Face, FaceDto>();
            CreateMap<ScanData, ScanDataForCreationDto>()
            .ForMember(c => c.ScanLocation,
                        opt => opt.MapFrom(x => string.Join(' ', x.devid, x.devname)));

        }
    }
}
