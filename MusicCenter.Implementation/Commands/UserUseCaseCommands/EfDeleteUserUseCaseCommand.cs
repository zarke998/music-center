using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.Commands.UserUseCaseCommands;
using MusicCenter.Application.Exceptions;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.UserUseCaseCommands
{
    public class EfDeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {
        private readonly MusicCenterDbContext _context;

        public int Id => 21;
        public string Name => "Ef Delete User Use Case";

        public EfDeleteUserUseCaseCommand(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public void Execute(int id)
        {
            var userUseCase = _context.UserUseCases.Find(id);

            if(userUseCase == null)
            {
                throw new EntityNotFoundException(typeof(UserUseCase), id);
            }

            _context.UserUseCases.Remove(userUseCase);

            _context.SaveChanges();
        }
    }
}
