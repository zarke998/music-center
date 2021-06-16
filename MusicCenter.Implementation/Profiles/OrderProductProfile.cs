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
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductDto>();
            CreateMap<CreateOrderProductDto, OrderProduct>();

            CreateMap<UpdateOrderProductDto, OrderProduct>()
                .ForAllMembers(opt => opt.PreCondition((dto, prod, srcMemb) => srcMemb != null));
        }
    }
}
