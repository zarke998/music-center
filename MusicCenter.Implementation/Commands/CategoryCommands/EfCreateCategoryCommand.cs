using AutoMapper;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.Commands.CategoryCommands;
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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 12;
        public string Name => "Ef Create Category";

        public EfCreateCategoryCommand(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(CategoryDto dto)
        {
            var newCategory = _mapper.Map<Category>(dto);
            newCategory.Id = 0;

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }
    }
}
