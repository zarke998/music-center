using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.UserCartProductCommands;
using MusicCenter.Application.Commands.UserUseCaseCommands;
using MusicCenter.Application.DTO;
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
    public class UserCartProductsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly MusicCenterDbContext _context;

        public UserCartProductsController(UseCaseExecutor executor, MusicCenterDbContext context)
        {
            _executor = executor;
            _context = context;
        }
        // POST api/<UserUseCasesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserCartProductDto dto,
                                [FromServices] ICreateUserCartProductCommand command,
                                [FromServices] CreateUserCartProductValidator validator)
        {
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<UserUseCasesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCartProductCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return NoContent();
        }
    }
}
