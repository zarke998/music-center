using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.UserQueries;
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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly MusicCenterDbContext _context;
        private readonly IMapper _mapper;

        public int Id => 15;
        public string Name => "Ef Get Users";

        public EfGetUsersQuery(MusicCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var users = _context.Users.AsQueryable();

            if (!String.IsNullOrEmpty(search.FirstName))
            {
                users = users.Where(u => u.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!String.IsNullOrEmpty(search.LastName))
            {
                users = users.Where(u => u.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!String.IsNullOrEmpty(search.Email))
            {
                users = users.Where(u => u.Email.ToLower().Contains(search.Email.ToLower()));
            }

            if (search.Gender.HasValue)
            {
                users = users.Where(u => u.Gender == search.Gender.Value);
            }

            return users.ToPagedResponse<UserDto, User>(search, _mapper);
        }
    }
}
