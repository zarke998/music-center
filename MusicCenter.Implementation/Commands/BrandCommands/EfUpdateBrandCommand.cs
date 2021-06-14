using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.DTO;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.BrandCommands
{
    public class EfUpdateBrandCommand : IUpdateBrandCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public EfUpdateBrandCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;
        public string Name => "Ef Update Brand";

        public void Execute(UpdateBrandDto dto)
        {
            var brand = _context.Brands.Find(dto.Id);

            _mapper.Map(dto, brand);

            _context.SaveChanges();
        }
    }
}
