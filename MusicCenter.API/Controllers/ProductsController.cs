using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.Application;
using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.DTO;
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
    public class ProductsController : ControllerBase
    {
        private readonly MusicCenterDbContext _context;

        private readonly UseCaseExecutor _executor;

        public ProductsController(MusicCenterDbContext context, UseCaseExecutor executor)
        {
            this._context = context;
            _executor = executor;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IGetSingleProductQuery query, int id)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateProductDto dto,
                                [FromServices] ICreateProductCommand command,
                                [FromServices] CreateProductValidator validator)
        {
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateProductDto dto,
                                        [FromServices] IUpdateProductCommand command,
                                        [FromServices] UpdateProductValidator validator)
        {
            if (!_context.Products.Any(p => p.Id == dto.Id))
                return NotFound();

            dto.Id = id;
            validator.ValidateAndThrow(dto);

            _executor.ExecuteCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            var productExists = _context.Products.Any(p => p.Id == id);

            if (!productExists)
            {
                return NotFound();
            }

            _executor.ExecuteCommand(command, id);

            return NoContent();
        }
    }
}
