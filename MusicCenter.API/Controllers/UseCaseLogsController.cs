using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.UserUseCaseCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries.UseCaseLogQueries;
using MusicCenter.Application.Queries.UserUseCaseQueries;
using MusicCenter.Application.Queries.UserUseCasesQueries;
using MusicCenter.Application.Searches;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly MusicCenterDbContext _context;

        public UseCaseLogsController(UseCaseExecutor executor, MusicCenterDbContext context)
        {
            _executor = executor;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
