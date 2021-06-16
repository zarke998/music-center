using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.ProductCommands;
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
    public class EfUpdateOrderCommand : IUpdateOrderCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 29;
        public string Name => "Ef Update Order";

        public EfUpdateOrderCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(UpdateOrderDto dto)
        {
            var order = _context.Orders.Find(dto.Id);

            _mapper.Map(dto, order);

            _context.SaveChanges();
        }
    }
}
