using MusicCenter.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries.OrderProductQueries
{
    public interface IGetSingleOrderProductQuery : IQuery<int, OrderProductDto>
    {

    }
}
