using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.Application.DTO;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Commands.CategoryCommands
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public EfUpdateCategoryCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 14;
        public string Name => "Ef Update Category";

        public void Execute(CategoryDto dto)
        {
            var category = _context.Categories.Find(dto.Id);

            _mapper.Map(dto, category);

            _context.SaveChanges();
        }
    }
}
