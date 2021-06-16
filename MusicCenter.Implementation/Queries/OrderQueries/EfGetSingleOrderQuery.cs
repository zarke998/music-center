using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Application.Queries.CategoryQueries;
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
    public class EfGetSingleOrderQuery : IGetSingleOrderQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 28;
        public string Name => "Ef Get Single Order";

        public EfGetSingleOrderQuery(MusicCenterDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public OrderDto Execute(int id)
        {
            var order = _context.Orders.Find(id);

            if(order == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            var dto = _mapper.Map<OrderDto>(order);

            return dto;
        }
    }
}
