using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.OrderCommands
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 26;
        public string Name => "Ef Create Order";

        public EfCreateOrderCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            
            _context.Orders.Add(order);

            _context.SaveChanges();
        }
    }
}
