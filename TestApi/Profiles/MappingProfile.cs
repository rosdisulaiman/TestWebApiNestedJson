using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestApi.Customization;
using TestApi.Models;
using TestApi.Models.DataTransferObjects;

namespace TestApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConverter>();

            CreateMap<ScanData, ScanDataDTO>()
                .ForMember(c => c.ScanLocation,
                        opt => opt.MapFrom(x => string.Join(' ', x.devid, x.devname)))
                .ForMember(dest => dest.time,
                        opt => opt.MapFrom(src => src.time.ToString()))
                .ForMember(dest => dest.timelocal,
                        opt => opt.MapFrom(src => src.time.ToString()));
                
                


            //CreateMap().ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            //CreateMap().ConvertUsing(x => x.ToDateTime());
            //.ForMember( time => time.logtime,
            //opt => opt.MapFrom(it => it.time.ToString()));

            CreateMap<ScanDataDTO, ScanData>();
            CreateMap<Face, FaceDto>();
            CreateMap<ScanData, ScanDataForCreationDto>()
            .ForMember(c => c.ScanLocation,
                        opt => opt.MapFrom(x => string.Join(' ', x.devid, x.devname)));

        }
    }
}
