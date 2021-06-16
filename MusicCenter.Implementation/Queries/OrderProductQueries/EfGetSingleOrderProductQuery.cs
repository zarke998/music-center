using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Application.Queries.CategoryQueries;
using MusicCenter.Application.Queries.OrderProductQueries;
using MusicCenter.Application.Queries.OrderQueries;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.OrderQueries
{
    public class EfGetSingleOrderProductQuery : IGetSingleOrderProductQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 32;
        public string Name => "Ef Get Single Order Prouduct";

        public EfGetSingleOrderProductQuery(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public OrderProductDto Execute(int id)
        {
            var orderProduct = _context.OrderProducts.Find(id);

            if(orderProduct == null)
            {
                throw new EntityNotFoundException(typeof(OrderProduct), id);
            }

            var dto = _mapper.Map<OrderProductDto>(orderProduct);

            return dto;
        }
    }
}
