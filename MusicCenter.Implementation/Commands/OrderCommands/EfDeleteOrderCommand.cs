using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.Application.Commands.OrderCommands;
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
    public class EfDeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly MusicCenterDbContext _context;

        public int Id => 30;
        public string Name => "Ef Delete Order";

        public EfDeleteOrderCommand(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Execute(int id)
        {
            var order = _context.Orders.Find(id);

            if(order == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            _context.Orders.Remove(order);

            _context.SaveChanges();
        }
    }
}
