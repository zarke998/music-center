using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly DbSeeder _seeder;

        public SeedController(DbSeeder seeder)
        {
            _seeder = seeder;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var seedSuccessfull = _seeder.Seed();
            if (!seedSuccessfull)
            {
                return Conflict("Database not empty. Could not seed.");
            }

            return Ok();
        }
    }
}
