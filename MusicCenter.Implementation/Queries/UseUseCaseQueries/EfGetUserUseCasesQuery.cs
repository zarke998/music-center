using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.UserQueries;
using MusicCenter.Application.Queries.UserUseCasesQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.UserUseCaseQueries
{
    public class EfGetUserUseCasesQuery : IGetUserUseCasesQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 23;
        public string Name => "Ef Get User Use Cases";

        public EfGetUserUseCasesQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResponse<UserUseCaseDto> Execute(UserUseCaseSearch search)
        {
            var userUseCases = _context.UserUseCases.AsQueryable();

            if (search.UserId.HasValue)
            {
                userUseCases = userUseCases.Where(uuc => uuc.UserId == search.UserId);
            }

            if (search.UseCaseId.HasValue)
            {
                userUseCases = userUseCases.Where(uuc => uuc.UseCaseId == search.UseCaseId);
            }

            return userUseCases.ToPagedResponse<UserUseCaseDto, UserUseCase>(search, _mapper);
        }
    }
}
