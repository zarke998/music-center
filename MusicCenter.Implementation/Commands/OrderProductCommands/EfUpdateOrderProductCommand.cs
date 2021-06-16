using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.OrderProductCommands;
using MusicCenter.Application.Commands.ProductCommands;
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
    public class EfUpdateOrderProductCommand : IUpdateOrderProductCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 33;
        public string Name => "Ef Update Order Product";

        public EfUpdateOrderProductCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(UpdateOrderProductDto dto)
        {
            var orderProduct = _context.OrderProducts.Find(dto.Id);

            _mapper.Map(dto, orderProduct);

            _context.SaveChanges();
        }
    }
}
