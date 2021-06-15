using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.ProductQueries;
using MusicCenter.Application.Queries.UseCaseLogQueries;
using MusicCenter.Application.Searches;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Queries.UseCaseLogQueries
{
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public EfGetUseCaseLogsQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public int Id => 25;
        public string Name => "Ef Get Use Case Logs";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var useCaseLogs = _context.UseCaseLogs.AsQueryable();

            if (search.DateFrom.HasValue)
            {
                useCaseLogs = useCaseLogs.Where(ucl => ucl.CreatedAt >= search.DateFrom.Value);
            }

            if (search.DateTo.HasValue)
            {
                useCaseLogs = useCaseLogs.Where(ucl => ucl.CreatedAt <= search.DateTo.Value);
            }

            if (search.UseCaseId.HasValue)
            {
                useCaseLogs = useCaseLogs.Where(ucl => ucl.UseCaseId == search.UseCaseId.Value);
            }

            if (!String.IsNullOrEmpty(search.UseCaseName))
            {
                useCaseLogs = useCaseLogs.Where(ucl => ucl.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (search.UserId.HasValue)
            {
                useCaseLogs = useCaseLogs.Where(ucl => ucl.UserId == search.UserId);
            }

            return useCaseLogs.ToPagedResponse<UseCaseLogDto, UseCaseLog>(search, _mapper);
        }
    }
}
