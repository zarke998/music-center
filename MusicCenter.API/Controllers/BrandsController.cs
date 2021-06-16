using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries;
using MusicCenter.Application.Queries.BrandQueries;
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
    public class BrandsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        private readonly MusicCenterDbContext _context;

        public BrandsController(UseCaseExecutor executor, IApplicationActor actor, MusicCenterDbContext context)
        {
            _executor = executor;
            _actor = actor;
            _context = context;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BrandSearch search, [FromServices] IGetBrandsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleBrandQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<BrandsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateBrandDto dto,
                                    [FromServices] ICreateBrandCommand command,
                                    [FromServices] CreateBrandValidator validator)
        {
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return NoContent();
        }

        // PUT api/<BrandsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                [FromBody] UpdateBrandDto dto,
                                [FromServices] IUpdateBrandCommand command,
                                [FromServices] UpdateBrandValidator validator)
        {
            dto.Id = id;
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<BrandsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            if(!_context.Brands.Any(b => b.Id == id))
            {
                return NotFound();
            }

            _executor.ExecuteCommand(command, id);

            return NoContent();
        }
    }
}
