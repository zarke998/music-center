using AutoMapper;
using MusicCenter.Application.Commands.UserCartProductCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.UserCartProductCommands
{
    public class EfCreateUserCartProductCommand : ICreateUserCartProductCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 22;
        public string Name => "Ef Create User Cart Product";

        public EfCreateUserCartProductCommand(MusicCenterDbContext contex, IMapper mapper)
        {
            this._context = contex;
            this._mapper = mapper;
        }

        public void Execute(CreateUserCartProductDto dto)
        {
            var cartProduct = _mapper.Map<UserCartProduct>(dto);

            _context.UserCartProducts.Add(cartProduct);

            _context.SaveChanges();
        }
    }
}
