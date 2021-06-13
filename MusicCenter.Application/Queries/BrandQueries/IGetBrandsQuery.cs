using MusicCenter.Application.DTO;
using MusicCenter.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries.BrandQueries
{
    public interface IGetBrandsQuery : IQuery<BrandSearch, PagedResponse<BrandDto>>
    {

    }
}
