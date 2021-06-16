using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.OrderProductCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.OrderProductCommands
{
    public class EfCreateOrderProductCommand : ICreateOrderProductCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 33;
        public string Name => "Ef Create Order Product";

        public EfCreateOrderProductCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(CreateOrderProductDto dto)
        {
            var orderProduct = _mapper.Map<OrderProduct>(dto);
            
            _context.OrderProducts.Add(orderProduct);

            _context.SaveChanges();
        }
    }
}
