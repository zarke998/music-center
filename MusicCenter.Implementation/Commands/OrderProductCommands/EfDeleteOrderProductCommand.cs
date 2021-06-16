using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.OrderProductCommands;
using MusicCenter.Application.Exceptions;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.OrderCommands
{
    public class EfDeleteOrderProductCommand : IDeleteOrderProductCommand
    {
        private readonly MusicCenterDbContext _context;

        public int Id => 34;
        public string Name => "Ef Delete Order Product";

        public EfDeleteOrderProductCommand(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Execute(int id)
        {
            var orderProduct = _context.OrderProducts.Find(id);

            if(orderProduct == null)
            {
                throw new EntityNotFoundException(typeof(OrderProduct), id);
            }

            _context.OrderProducts.Remove(orderProduct);

            _context.SaveChanges();
        }
    }
}
