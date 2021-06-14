using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.CategoryCommands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly MusicCenterDbContext _context;

        public int Id => 13;
        public string Name => "Ef Delete Category";

        public EfDeleteCategoryCommand(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Execute(int id)
        {
            var category = _context.Categories.Find(id);

            _context.Categories.Remove(category);

            _context.SaveChanges();
        }
    }
}
