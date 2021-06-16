using MusicCenter.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries.OrderQueries
{
    public interface IGetSingleOrderQuery : IQuery<int, OrderDto>
    {

    }
}
