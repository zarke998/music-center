using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.OrderProductCommands;
using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.DTO;
using MusicCenter.Application.Queries.OrderLineQueries;
using MusicCenter.Application.Queries.OrderProductQueries;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly MusicCenterDbContext _context;

        private readonly UseCaseExecutor _executor;

        public OrderProductsController(MusicCenterDbContext context, UseCaseExecutor executor)
        {
            this._context = context;
            _executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] OrderProductSearch search, [FromServices] IGetOrderProductsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IGetSingleOrderProductQuery query, int id)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderProductDto dto,
                [FromServices] ICreateOrderProductCommand command,
                [FromServices] CreateOrderProductValidator validator)
        {
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
