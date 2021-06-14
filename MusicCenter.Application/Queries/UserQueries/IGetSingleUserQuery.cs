using MusicCenter.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries.UserQueries
{
    public interface IGetSingleUserQuery : IQuery<int, UserDto>
    {

    }
}
