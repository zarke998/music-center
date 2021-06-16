using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.CategoryQueries;
using MusicCenter.Application.Queries.OrderLineQueries;
using MusicCenter.Application.Queries.OrderQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.OrderProductQueries
{
    public class EfGetOrderProductsQuery : IGetOrderProductsQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 31;
        public string Name => "Ef Get Order Products";

        public EfGetOrderProductsQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResponse<OrderProductDto> Execute(OrderProductSearch search)
        {
            var orderProducts = _context.OrderProducts.AsQueryable();

            if (!String.IsNullOrEmpty(search.Name))
            {
                orderProducts = orderProducts.Where(op => op.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.MinPrice.HasValue)
            {
                orderProducts = orderProducts.Where(op => op.Price >= search.MinPrice.Value);
            }

            if (search.MaxPrice.HasValue)
            {
                orderProducts = orderProducts.Where(op => op.Price <= search.MaxPrice.Value);
            }

            if (search.Quantity.HasValue)
            {
                orderProducts = orderProducts.Where(op => op.Quantity == search.Quantity.Value);
            }

            if (search.OrderId.HasValue)
            {
                orderProducts = orderProducts.Where(op => op.OrderId == search.OrderId.Value);
            }

            return orderProducts.ToPagedResponse<OrderProductDto, OrderProduct>(search, _mapper);
        }
    }
}
