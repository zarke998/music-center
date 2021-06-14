using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Application.Queries.CategoryQueries;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.CategoryQueries
{
    public class EfGetSingleCategoryQuery : IGetSingleCategoryQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 11;
        public string Name => "Ef Get Single Category";

        public EfGetSingleCategoryQuery(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public CategoryDto Execute(int id)
        {
            var category = _context.Categories.Find(id);

            if(category == null)
            {
                throw new EntityNotFoundException(typeof(Category), id);
            }

            var dto = _mapper.Map<CategoryDto>(category);

            return dto;
        }
    }
}
