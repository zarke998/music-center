using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.BrandQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.BrandQueries
{
    public class EfGetBrandsQuery : IGetBrandsQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 6;
        public string Name => "Ef Get Brands";

        public EfGetBrandsQuery(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public PagedResponse<BrandDto> Execute(BrandSearch search)
        {
            var brands = _context.Brands.AsQueryable();

            if (!String.IsNullOrEmpty(search.Name))
            {
                brands = brands.Where(b => b.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return brands.ToPagedResponse<BrandDto, Brand>(search, _mapper);
        }
    }
}
