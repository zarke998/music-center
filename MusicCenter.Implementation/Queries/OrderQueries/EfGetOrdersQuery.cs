using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.CategoryQueries;
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

namespace MusicCenter.Implementation.Queries.OrderQueries
{
    public class EfGetOrdersQuery : IGetOrdersQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 27;
        public string Name => "Ef Get Orders";

        public EfGetOrdersQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResponse<OrderDto> Execute(OrderSearch search)
        {
            var orders = _context.Orders.AsQueryable();

            if (!String.IsNullOrEmpty(search.ShippingAdress))
            {
                orders = orders.Where(o => o.ShippingAdress.ToLower().Contains(search.ShippingAdress.ToLower()));
            }

            if (search.UserId.HasValue)
            {
                orders = orders.Where(o => o.UserId == search.UserId.Value);
            }

            if (search.CreatedFrom.HasValue)
            {
                orders = orders.Where(o => o.CreatedAt >= search.CreatedFrom.Value);
            }

            if (search.CreatedTo.HasValue)
            {
                orders = orders.Where(o => o.CreatedAt <= search.CreatedTo.Value);
            }

            return orders.ToPagedResponse<OrderDto, Order>(search, _mapper);
        }
    }
}
