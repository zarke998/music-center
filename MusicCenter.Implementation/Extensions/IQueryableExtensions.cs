using AutoMapper;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Extensions
{
    public static class IQueryableExtensions
    {

        /// <summary>
        /// Executes query and returns a page of searched objects.
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="search"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static PagedResponse<TDto> ToPagedResponse<TDto, TEntity>(this IQueryable<TEntity> query, 
                                                                            PagedSearch search, 
                                                                            IMapper mapper) where TDto : class
        {
            var totalCount = query.Count();
            var skipCount = (search.Page - 1) * search.PerPage;

            var queryResult = query.Skip(skipCount).Take(search.PerPage).ToList();

            var resultDtos = mapper.Map<IEnumerable<TDto>>(queryResult);

            return new PagedResponse<TDto>()
            {
                TotalCount = totalCount,
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Items = resultDtos
            };
        }
    }
}
