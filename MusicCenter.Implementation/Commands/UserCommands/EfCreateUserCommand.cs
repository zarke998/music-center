using AutoMapper;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.UserCommands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 17;
        public string Name => "Ef Create User";

        public EfCreateUserCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
