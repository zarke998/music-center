using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>();
            CreateMap<Order, OrderDto>();

            CreateMap<UpdateOrderDto, Order>()
                .ForAllMembers(opt => opt.PreCondition((dto, prod, srcMemb) => srcMemb != null));
        }
    }
}
