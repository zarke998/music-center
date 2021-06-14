using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.CategoryQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.CategoryQueries
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 10;
        public string Name => "Ef Get Categories";

        public EfGetCategoriesQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var categories = _context.Categories.AsQueryable();

            if (!String.IsNullOrEmpty(search.Name))
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return categories.ToPagedResponse<CategoryDto, Category>(search, _mapper);
        }
    }
}
