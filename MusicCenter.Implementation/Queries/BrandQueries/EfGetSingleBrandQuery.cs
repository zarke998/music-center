using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Application.Queries.BrandQueries;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.BrandQueries
{
    public class EfGetSingleBrandQuery : IGetSingleBrandQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 7;
        public string Name => "Ef Get Single Brand";

        public EfGetSingleBrandQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public BrandDto Execute(int id)
        {
            var brand = _context.Brands.Find(id);

            if (brand == null)
            {
                throw new EntityNotFoundException(typeof(Brand), id);
            }

            return _mapper.Map<BrandDto>(brand);
        }
    }
}
