using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.Commands.ProductCommands;
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
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 18;
        public string Name => "Ef Update User ";

        public EfUpdateUserCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(UpdateUserDto dto)
        {
            var user = _context.Users.Find(dto.Id);

            _mapper.Map(dto, user);

            _context.SaveChanges();
        }
    }
}
