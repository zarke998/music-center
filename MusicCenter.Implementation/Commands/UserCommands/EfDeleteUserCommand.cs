using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.Exceptions;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.UserCommands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly MusicCenterDbContext _context;

        public int Id => 19;
        public string Name => "Ef Delete User";

        public EfDeleteUserCommand(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Execute(int id)
        {
            var user = _context.Users.Find(id);

            if(user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            _context.Users.Remove(user);

            _context.SaveChanges();
        }
    }
}
