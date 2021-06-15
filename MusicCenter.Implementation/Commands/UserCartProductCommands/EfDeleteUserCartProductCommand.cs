using AutoMapper;
using MusicCenter.Application.Commands.UserCartProductCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.UserCartProductCommands
{
    public class EfDeleteUserCartProductCommand : IDeleteUserCartProductCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 23;
        public string Name => "Ef Delete User Cart Product";

        public EfDeleteUserCartProductCommand(MusicCenterDbContext contex, IMapper mapper)
        {
            this._context = contex;
            this._mapper = mapper;
        }

        public void Execute(int id)
        {
            var cartProduct = _context.UserCartProducts.Find(id);

            if(cartProduct == null)
            {
                throw new EntityNotFoundException(typeof(UserCartProduct), id);
            }

            _context.UserCartProducts.Remove(cartProduct);

            _context.SaveChanges();
        }
    }
}
