using MusicCenter.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries.ProductQueries
{
    public interface IGetSingleProductQuery : IQuery<int, ProductDto>
    {

    }
}
