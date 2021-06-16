using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries.OrderQueries;
using MusicCenter.Application.Queries.ProductQueries;
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
    public class OrdersController : ControllerBase
    {
        private readonly MusicCenterDbContext _context;

        private readonly UseCaseExecutor _executor;

        public OrdersController(MusicCenterDbContext context, UseCaseExecutor executor)
        {
            this._context = context;
            _executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IGetSingleOrderQuery query, int id)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateOrderDto dto,
                        [FromServices] ICreateOrderCommand command,
                        [FromServices] CreateOrderValidator validator)
        {
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateOrderDto dto,
                                [FromServices] IUpdateOrderCommand command,
                                [FromServices] UpdateOrderValidator validator)
        {
            dto.Id = id;
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return NoContent();
        }

    }
}
