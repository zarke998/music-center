using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.BrandCommands
{
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public EfDeleteBrandCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 10;
        public string Name => "Ef Delete Brand";

        public void Execute(int id)
        {
            var brand = _context.Brands.Find(id);

            _context.Brands.Remove(brand);

            _context.SaveChanges();
        }
    }
}
