﻿using FluentValidation;
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
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto dto,
                                [FromServices] ICreateUserCommand command,
                                [FromServices] CreateUserValidator validator)
        {
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
