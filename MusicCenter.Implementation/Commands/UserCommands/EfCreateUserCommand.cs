using AutoMapper;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Email;
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
        private readonly IEmailSender _emailSender;

        public int Id => 17;
        public string Name => "Ef Create User";

        public EfCreateUserCommand(MusicCenterDbContext context, IMapper mapper, IEmailSender emailSender)
        {
            this._context = context;
            this._mapper = mapper;
            _emailSender = emailSender;
        }

        public void Execute(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _context.Users.Add(user);
            _context.SaveChanges();

            _emailSender.Send(new SendEmailDto()
            {
                SendTo = user.Email,
                Subject = "MusicCenter - Registration",
                Content = "You have successfully registered."
            });
        }
    }
}
