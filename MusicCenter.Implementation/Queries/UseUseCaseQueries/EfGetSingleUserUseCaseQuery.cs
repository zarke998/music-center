using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Exceptions;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.UserQueries;
using MusicCenter.Application.Queries.UserUseCaseQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.UserQueries
{
    public class EfGetSingleUserUseCaseQuery : IGetSingleUserUseCaseQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 24;
        public string Name => "Ef Get Single Users";

        public EfGetSingleUserUseCaseQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserUseCaseDto Execute(int id)
        {
            var userUseCase = _context.UserUseCases.Find(id);

            if (userUseCase == null)
            {
                throw new EntityNotFoundException(typeof(UserUseCase), id);
            }

            return _mapper.Map<UserUseCaseDto>(userUseCase);
        }
    }
}
