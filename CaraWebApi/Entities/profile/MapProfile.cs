using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.profile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<DomainClass, Parent>();
            CreateMap<DomainClass, Child>();


      

            CreateMap<DomainClass, Child>();
            CreateMap<DomainClass, Parent>()
                .ForMember(d => d.Child, opt => opt.MapFrom(s => s));


            //CreateMap<DomainClass, Parent>(MemberList.None)
            //.ForMember(dest => dest.Id,
            //    opts => opts.MapFrom(src => src.Id))
            //.ForMember(dest => dest.OrderDate,
            //    opts => opts.MapFrom(src => src.OrderDate))
            //.ForMember(dest => dest.OrderedBy,
            //    opts => opts.MapFrom(src => src.OrderedBy))
            //.ForMember(dest => dest.ItemsDto,
            //    opt => opt.MapFrom(src => src.Items));


            //CreateMap<Order, OrderDto>(MemberList.None)
            //.ForMember(dest => dest.OrderId,
            //    opts => opts.MapFrom(src => src.OrderId))
            //.ForMember(dest => dest.OrderDate,
            //    opts => opts.MapFrom(src => src.OrderDate))
            //.ForMember(dest => dest.OrderedBy,
            //    opts => opts.MapFrom(src => src.OrderedBy))
            //.ForMember(dest => dest.ItemsDto,
            //    opt => opt.MapFrom(src => src.Items));


            //CreateMap<OrderItem, OrderItemDto>(MemberList.None)
            //.ForMember(dest => dest.ItemId,
            //    opts => opts.MapFrom(src => src.ItemId))
            //.ForMember(dest => dest.ItemPrice,
            //    opts => opts.MapFrom(src => src.ItemPrice))
            //.ForMember(dest => dest.Name,
            //    opts => opts.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Quantity,
            //    opts => opts.MapFrom(src => src.Quantity))
            //.ForMember(dest => dest.ItemTotal,
            //    opts => opts.MapFrom(src => src.ItemTotal));
        }
    }
}
