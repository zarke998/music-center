using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.ProductCommands
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly MusicCenterDbContext _context;

        public int Id => 5;
        public string Name => "Ef Delete Product";

        public EfDeleteProductCommand(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);
            _context.Products.Remove(product);

            _context.SaveChanges();
        }
    }
}
