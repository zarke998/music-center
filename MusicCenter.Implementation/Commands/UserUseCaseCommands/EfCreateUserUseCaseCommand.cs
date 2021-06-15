using AutoMapper;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.Commands.UserUseCaseCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.UserUseCaseCommands
{
    public class EfCreateUserUseCaseCommand : ICreateUserUseCaseCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 20;
        public string Name => "Ef Create User Use Case";

        public EfCreateUserUseCaseCommand(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Execute(CreateUserUseCaseDto dto)
        {
            var userUseCase = _mapper.Map<UserUseCase>(dto);

            _context.UserUseCases.Add(userUseCase);

            _context.SaveChanges();
        }
    }
}
