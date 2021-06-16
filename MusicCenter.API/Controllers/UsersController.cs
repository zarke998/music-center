using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries.UserQueries;
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
    public class UsersController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly MusicCenterDbContext _context;

        public UsersController(UseCaseExecutor executor, IApplicationActor actor, MusicCenterDbContext context)
        {
            _executor = executor;            
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IGetSingleUserQuery query, int id)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<UserController>


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id,
                                [FromBody] UpdateUserDto dto,
                                [FromServices] IUpdateUserCommand command,
                                [FromServices] UpdateUserValidator validator)
        {
            if (!_context.Users.Any(u => u.Id == dto.Id))
                return NotFound();

            dto.Id = id;
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return NoContent();
        }
    }
}
