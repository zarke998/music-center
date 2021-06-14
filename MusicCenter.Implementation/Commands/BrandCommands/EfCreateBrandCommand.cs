using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.BrandCommands
{
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 8;
        public string Name => "Ef Create Brand";

        public EfCreateBrandCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(CreateBrandDto dto)
        {
            var newBrand = _mapper.Map<Brand>(dto);

            _context.Brands.Add(newBrand);
            _context.SaveChanges();
        }
    }
}
