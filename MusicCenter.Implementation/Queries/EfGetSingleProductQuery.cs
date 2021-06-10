using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Application.Queries;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries
{
    public class EfGetSingleProductQuery : IGetSingleProductQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 2;
        public string Name => "Ef Get Single Product";

        public EfGetSingleProductQuery(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public ProductDto Execute(int id)
        {
            var product = _context.Products.Include(p => p.Brand)
                                            .Include(p => p.ProductCategories).ThenInclude(pc => pc.Category)
                                            .FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                throw new EntityNotFoundException(typeof(Product), id);
            }

            return _mapper.Map<ProductDto>(product);
        }
    }
}
