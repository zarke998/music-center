using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.ProductQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.ProductQueries
{
    public class EfGetProductsQuery : IGetProductsQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public EfGetProductsQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public int Id => 1;
        public string Name => "Ef Get Products";

        public PagedResponse<ProductDto> Execute(ProductSearch search)
        {
            var products = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductCategories).ThenInclude(pc => pc.Category)
                .AsQueryable();

            if (!String.IsNullOrEmpty(search.Keyword))
            {
                string keyword = search.Keyword.ToLower();
                products = products
                    .Where(p => p.Name.ToLower().Contains(keyword) ||
                            p.Brand.Name.ToLower().Contains(keyword) || 
                            p.ProductCategories.Any(pc => pc.Category.Name.ToLower().Contains(keyword)));
            }

            if (search.MinPrice.HasValue)
            {
                products = products.Where(p => p.Price >= search.MinPrice);
            }
            if (search.MaxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= search.MaxPrice);
            }

            return products.ToPagedResponse<ProductDto, Product>(search, _mapper);
        }
    }
}
